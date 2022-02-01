import random
import tkinter as tk
from tkinter import font  as tkfont
import numpy as np
 

#################################################################
##
##  variables du jeu 
 
# 0 vide
# 1 mur
# 2 maison des fantomes (ils peuvent circuler mais pas pacman)

TBL = [ [1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1],
        [1,3,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,3,1],
        [1,0,1,1,0,1,0,1,1,1,1,1,1,0,1,0,1,1,0,1],
        [1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1],
        [1,0,1,0,1,1,0,1,1,2,2,1,1,0,1,1,0,1,0,1],
        [1,0,0,0,0,0,0,1,2,2,2,2,1,0,0,0,0,0,0,1],
        [1,0,1,0,1,1,0,1,1,1,1,1,1,0,1,1,0,1,0,1],
        [1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1],
        [1,0,1,1,0,1,0,1,1,1,1,1,1,0,1,0,1,1,0,1],
        [1,3,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,3,1],
        [1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1] ]
        
        
TBL = np.array(TBL,dtype=np.int32)
TBL = TBL.transpose()  ## ainsi, on peut écrire TBL[x][y]


        
ZOOM = 40   # taille d'une case en pixels
EPAISS = 8  # epaisseur des murs bleus en pixels
HAUTEUR = TBL.shape [1]      
LARGEUR = TBL.shape [0]

SCORE = 0
LIMIT = 0

screeenWidth = (LARGEUR+1) * ZOOM
screenHeight = (HAUTEUR+2) * ZOOM
 


###########################################################################################

# création de la fenetre principale  -- NE PAS TOUCHER

Window = tk.Tk()
Window.geometry(str(screeenWidth)+"x"+str(screenHeight))   # taille de la fenetre
Window.title("ESIEE - PACMAN")

# création de la frame principale stockant plusieurs pages

F = tk.Frame(Window)
F.pack(side="top", fill="both", expand=True)
F.grid_rowconfigure(0, weight=1)
F.grid_columnconfigure(0, weight=1)

# gestion des différentes pages

ListePages  = {}
PageActive = 0

def CreerUnePage(id):
    Frame = tk.Frame(F)
    ListePages[id] = Frame
    Frame.grid(row=0, column=0, sticky="nsew")
    return Frame

def AfficherPage(id):
    global PageActive
    PageActive = id
    ListePages[id].tkraise()
    
    
def WindowAnim():
    MainLoop()
    Window.after(500,WindowAnim)

Window.after(100,WindowAnim)

# Ressources

PoliceTexte = tkfont.Font(family='Arial', size=22, weight="bold", slant="italic")

# création de la zone de dessin

Frame1 = CreerUnePage(0)

canvas = tk.Canvas( Frame1, width = screeenWidth, height = screenHeight )
canvas.place(x=0,y=0)
canvas.configure(background='black')
 
################################################################################
#
# placements des pacgums et des fantomes

def PlacementsGUM():  # placements des pacgums
   global LIMIT
   GUM = np.zeros(TBL.shape)
   
   for x in range(LARGEUR):
      for y in range(HAUTEUR):
         if ( TBL[x][y] == 0):
            GUM[x][y] = 1
            LIMIT += 1
         elif ( TBL[x][y] == 3):
            GUM[x][y] = 2
            LIMIT += 1
   return GUM
            
GUM = PlacementsGUM()   

PacManPos = [1,1]
HUNTING = 0

Ghosts  = []
Ghosts.append(  [LARGEUR//2-1, HAUTEUR // 2 ,  "pink",   (0,-1)]   )
Ghosts.append(  [LARGEUR//2-1, HAUTEUR // 2 ,  "orange", (0,-1)] )
Ghosts.append(  [LARGEUR//2-1, HAUTEUR // 2 ,  "cyan",   (0,-1)]   )
Ghosts.append(  [LARGEUR//2-1, HAUTEUR // 2 ,  "red",    (0,-1)]     )         

 
 
#################################################################
##
##  FNT AFFICHAGE



def To(coord):
   return coord * ZOOM + ZOOM 
   
# dessine l'ensemble des éléments du jeu par dessus le décor

anim_bouche = 0
animPacman = [ 5,10,15,10,5]


def Affiche():
   global anim_bouche
   
   def CreateCircle(x,y,r,coul):
      canvas.create_oval(x-r,y-r,x+r,y+r, fill=coul, width  = 0)
   
   canvas.delete("all")
      
      
   # murs
   
   for x in range(LARGEUR-1):
      for y in range(HAUTEUR):
         if ( TBL[x][y] == 1 and TBL[x+1][y] == 1 ):
            xx = To(x)
            xxx = To(x+1)
            yy = To(y)
            canvas.create_line(xx,yy,xxx,yy,width = EPAISS,fill="blue")

   for x in range(LARGEUR):
      for y in range(HAUTEUR-1):
         if ( TBL[x][y] == 1 and TBL[x][y+1] == 1 ):
            xx = To(x) 
            yy = To(y)
            yyy = To(y+1)
            canvas.create_line(xx,yy,xx,yyy,width = EPAISS,fill="blue")
            
   # pacgum
   for x in range(LARGEUR):
      for y in range(HAUTEUR):
         if ( GUM[x][y] == 1):
            xx = To(x) 
            yy = To(y)
            e = 5
            canvas.create_oval(xx-e,yy-e,xx+e,yy+e,fill="orange")

   # super pacgum
   for x in range(LARGEUR):
      for y in range(HAUTEUR):
         if ( GUM[x][y] == 2):
            xx = To(x) 
            yy = To(y)
            e = 10
            canvas.create_oval(xx-e,yy-e,xx+e,yy+e,fill="orange")
            
   #extra info
   #GumDistGrid
   for x in range(LARGEUR):
      for y in range(HAUTEUR):
         xx = To(x) 
         yy = To(y) + 10
         txt = str(GUM_DIST_GRID[x][y])
         canvas.create_text(xx,yy, text = txt, fill ="white", font=("Purisa", 8)) 
   #PacManDistGrid
   for x in range(LARGEUR):
      for y in range(HAUTEUR):
         xx = To(x) 
         yy = To(y) + 20
         txt = str(PACMAN_DIST_GRID[x][y])
         canvas.create_text(xx,yy, text = txt, fill ="red", font=("Purisa", 8)) 
  
   # dessine pacman
   xx = To(PacManPos[0]) 
   yy = To(PacManPos[1])
   e = 20
   anim_bouche = (anim_bouche+1)%len(animPacman)
   ouv_bouche = animPacman[anim_bouche] 
   tour = 360 - 2 * ouv_bouche
   canvas.create_oval(xx-e,yy-e, xx+e,yy+e, fill = "yellow")
   canvas.create_polygon(xx,yy,xx+e,yy+ouv_bouche,xx+e,yy-ouv_bouche, fill="black")  # bouche
   
  
   #dessine les fantomes
   dec = -3
   for P in Ghosts:
      xx = To(P[0]) 
      yy = To(P[1])
      e = 16
      
      coul = P[2]
      # corps du fantome
      CreateCircle(dec+xx,dec+yy-e+6,e,coul)
      canvas.create_rectangle(dec+xx-e,dec+yy-e,dec+xx+e+1,dec+yy+e, fill=coul, width  = 0)
      
      # oeil gauche
      CreateCircle(dec+xx-7,dec+yy-8,5,"white")
      CreateCircle(dec+xx-7,dec+yy-8,3,"black")
       
      # oeil droit
      CreateCircle(dec+xx+7,dec+yy-8,5,"white")
      CreateCircle(dec+xx+7,dec+yy-8,3,"black")
      
      dec += 3
     
   # texte blabla
   
   canvas.create_text(screeenWidth // 2, screenHeight- 50 , text = "Score : " + str(SCORE) + "    GOAL : " + str(LIMIT), fill ="yellow", font = PoliceTexte)
 
            
#################################################################
##
##  IA RANDOM

def UpdateGumDistGrid(): # Mise à jour de la grille de distance des pacgums
   global GUM_DIST_GRID

   for x in range(LARGEUR):	
      for y in range(HAUTEUR):	
         if (TBL[x][y]%3 == 0):
            if (GUM[x][y] == 0):
               GUM_DIST_GRID[x][y] = 99
            else:
               GUM_DIST_GRID[x][y] = 0

   updated = True	
   while updated:	
      updated = False	
      for x in range(LARGEUR):	
         for y in range(HAUTEUR):	
            if (TBL[x][y]%3 == 0 and GUM[x][y] == 0):
               minVal = min(GUM_DIST_GRID[x+1][y], GUM_DIST_GRID[x-1][y], GUM_DIST_GRID[x][y+1], GUM_DIST_GRID[x][y-1]) + 1	
               if minVal + 1 < GUM_DIST_GRID[x][y] :	
                  GUM_DIST_GRID[x][y] = minVal
                  updated = True

def InitGumDistGrid():  # Initialisation de la grille de distance des pacgums
   GUM_DIST_GRID = np.zeros(TBL.shape, np.int32)
   
   for x in range(LARGEUR):
      for y in range(HAUTEUR):
         if ( TBL[x][y]%3 != 0):
            GUM_DIST_GRID[x][y] = 1000
         else:
            GUM_DIST_GRID[x][y] = 0
   return GUM_DIST_GRID

GUM_DIST_GRID = InitGumDistGrid()
UpdateGumDistGrid()

def UpdatePacManDistGrid(): # Mise à jour de la grille de distance des pacgums
   global PACMAN_DIST_GRID, TBL	
   updated = True	
   while updated:	
      updated = False	
      for x in range(LARGEUR):	
         for y in range(HAUTEUR):	
            if (TBL[x][y]%3 == 0):	
               minVal = min([PACMAN_DIST_GRID[x+1][y], PACMAN_DIST_GRID[x-1][y], PACMAN_DIST_GRID[x][y+1], PACMAN_DIST_GRID[x][y-1]])	
               if minVal + 1 < PACMAN_DIST_GRID[x][y] :	
                  PACMAN_DIST_GRID[x][y] = minVal + 1	
                  updated = True

def InitPacManDistGrid():  # Initialisation de la grille de distance des pacgums
   PACMAN_DIST_GRID = np.zeros(TBL.shape, np.int32)
   for x in range(LARGEUR):	
      for y in range(HAUTEUR):	
         if ( TBL[x][y] != 0 and TBL[x][y] != 3):	
            PACMAN_DIST_GRID[x][y] = 1000
         else:
            PACMAN_DIST_GRID[x][y] = 99
   for F in Ghosts:
      PACMAN_DIST_GRID[F[0]][F[1]] = 0

   return PACMAN_DIST_GRID

def MarkDangerFrom(x,y):
   global PACMAN_DIST_GRID, GUM_DIST_GRID
   if PACMAN_DIST_GRID[x][y] == 1:
      GUM_DIST_GRID[x][y] = 100
   else:
      poss_cases = [(x,y-1), (x,y+1), (x+1,y), (x-1,y)]
      cases_dists = [PACMAN_DIST_GRID[x][y] for (x,y) in poss_cases]
      next_case = poss_cases[cases_dists.index(min(cases_dists))]
      MarkDangerFrom(next_case[0], next_case[1])

PACMAN_DIST_GRID = InitGumDistGrid()
      
def PacManPossibleMove():
   L = []
   x,y = PacManPos
   if ( TBL[x  ][y-1]%3 == 0 ): L.append((0,-1))
   if ( TBL[x  ][y+1]%3 == 0 ): L.append((0, 1))
   if ( TBL[x+1][y  ]%3 == 0 ): L.append(( 1,0))
   if ( TBL[x-1][y  ]%3 == 0 ): L.append((-1,0))
   return L
   
def GhostsPossibleMove(x,y, direction):
   if ( TBL[x  ][y  ] == 2 ): return [direction]
   L = []
   if ( TBL[x  ][y-1]%3 == 0) and (direction != ( 0, 1)): L.append(( 0,-1))
   if ( TBL[x  ][y+1]%3 == 0) and (direction != ( 0,-1)): L.append(( 0, 1))
   if ( TBL[x+1][y  ]%3 == 0) and (direction != (-1, 0)): L.append(( 1, 0))
   if ( TBL[x-1][y  ]%3 == 0) and (direction != ( 1, 0)): L.append((-1, 0))
   return L
   
def IA():
   global PacManPos, Ghosts, GUM_DIST_GRID, PACMAN_DIST_GRID, SCORE, LIMIT, HUNTING

   UpdateGumDistGrid()
   PACMAN_DIST_GRID = InitPacManDistGrid()
   UpdatePacManDistGrid()
   wasHunting = False
   #deplacement Pacman
   L = PacManPossibleMove()
   if HUNTING > 0:
      dists = [PACMAN_DIST_GRID[PacManPos[0] + x][PacManPos[1] + y] for (x,y) in L]
      HUNTING -= 1
      wasHunting = True
      choix = L[dists.index(min(dists))]
   else:
      if PACMAN_DIST_GRID[PacManPos[0]][PacManPos[1]] <= 3:	
         dists = [PACMAN_DIST_GRID[PacManPos[0] + x][PacManPos[1] + y] for (x,y) in L]
         choix = L[dists.index(max(dists))]
      else:
         dists = [GUM_DIST_GRID[PacManPos[0] + x][PacManPos[1] + y] for (x,y) in L]
         choix = L[dists.index(min(dists))]
   PacManPos[0] += choix[0]
   PacManPos[1] += choix[1]

   # Collision post-deplacement
   for F in Ghosts:	
      if [F[0],F[1]] == PacManPos:
         if not wasHunting:
            print("Score final : " + str(SCORE))	
            return True
         else:
            SCORE+=1
            LIMIT+=1
            F[0] = LARGEUR//2-1
            F[1] = HAUTEUR // 2
            F[3] = (0,-1)

   
   #deplacement Fantome
   for F in Ghosts:
      L = GhostsPossibleMove(F[0],F[1],F[3])
      choix = random.randrange(len(L))
      F[0] += L[choix][0]
      F[1] += L[choix][1]
      F[3] = L[choix]
      if [F[0],F[1]] == PacManPos:
         if not wasHunting:
            print("Score final : " + str(SCORE))	
            return True
         else:
            SCORE+=1
            LIMIT+=1
            F[0] = LARGEUR//2-1
            F[1] = HAUTEUR // 2
            F[3] = (0,-1)
   return False

   
 

#################################################################
##
##   GAME LOOP

def EatGum(x, y):
   global SCORE, LIMIT, GUM, GUM_DIST_GRID, HUNTING
   GUM[x][y] = 0
   SCORE += 1

def MainLoop():
  global HUNTING
  done = IA()
  if GUM[PacManPos[0]][PacManPos[1]] != 0:
      if GUM[PacManPos[0]][PacManPos[1]] == 2:
         HUNTING = 16
      EatGum(PacManPos[0],PacManPos[1])

  if SCORE == LIMIT:	
      print("YOU WIN")	
      done = True	

  Affiche()

  if done == True:
     Window.quit()
 
 
###########################################:
#  demarrage de la fenetre - ne pas toucher

AfficherPage(0)
Window.mainloop()
   
   
    
   
   