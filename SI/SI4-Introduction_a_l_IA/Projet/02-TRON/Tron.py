import tkinter as tk
import random
import numpy as np
import copy 
import time

#################################################################################
#
#   Données de partie

Data = [   [1,1,1,1,1,1,1,1,1,1,1,1,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,0,0,0,0,0,0,0,0,0,0,0,1],
           [1,1,1,1,1,1,1,1,1,1,1,1,1] ]

GInit  = np.array(Data,dtype=np.int8)
GInit  = np.flip(GInit,0).transpose()

LARGEUR = 13
HAUTEUR = 17

# container pour passer efficacement toutes les données de la partie

class Game:
    def __init__(self, Grille, PlayerX, PlayerY, Score=0):
        self.PlayerX = PlayerX
        self.PlayerY = PlayerY
        self.Score   = Score
        self.Grille  = Grille
    
    def copy(self): 
        return copy.deepcopy(self)

GameInit = Game(GInit,1,1)

##############################################################
#
#   création de la fenetre principale  - NE PAS TOUCHER

L = 20  # largeur d'une case du jeu en pixel    
largeurPix = LARGEUR * L
hauteurPix = HAUTEUR * L


Window = tk.Tk()
Window.geometry(str(largeurPix)+"x"+str(hauteurPix))   # taille de la fenetre
Window.title("TRON")


# création de la frame principale stockant toutes les pages

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
    
Frame0 = CreerUnePage(0)

canvas = tk.Canvas(Frame0,width = largeurPix, height = hauteurPix, bg ="black" )
canvas.place(x=0,y=0)

#   Dessine la grille de jeu - ne pas toucher


def Affiche(Game):
    canvas.delete("all")
    H = canvas.winfo_height()
    
    def DrawCase(x,y,coul):
        x *= L
        y *= L
        canvas.create_rectangle(x,H-y,x+L,H-y-L,fill=coul)
    
    # dessin des murs 
   
    for x in range (LARGEUR):
       for y in range (HAUTEUR):
           if Game.Grille[x,y] == 1  : DrawCase(x,y,"gray" )
           if Game.Grille[x,y] == 2  : DrawCase(x,y,"cyan" )
   
    
    # dessin de la moto
    DrawCase(Game.PlayerX,Game.PlayerY,"red" )

def AfficheScore(Game):
   info = "SCORE : " + str(Game.Score)
   canvas.create_text(80, 13,   font='Helvetica 12 bold', fill="yellow", text=info)


###########################################################
#
# gestion du joueur IA

# VOTRE CODE ICI

#############################################################
#
#  affichage en mode texte


def AffGrilles(G,X,Y):
    nbG, larg , haut = G.shape
    for y in range(haut-1,-1,-1) :
        for i in range(nbG) :
            for x in range(larg) :
               g = G[i]
               c = ' '
               if G[i,x,y] == 1 : c = 'M'  # mur
               if G[i,x,y] == 2 : c = 'O'  # trace
               if (X[i],Y[i]) == (x,y) : c ='X'  # joueur
               print(c,sep='', end = '')
            print(" ",sep='', end = '') # espace entre les grilles
        print("") # retour à la ligne


###########################################################
#
# simulation en parallèle des parties


# Liste des directions :
# 0 : sur place   1: à gauche  2 : en haut   3: à droite    4: en bas

dx = np.array([0, -1, 0,  1,  0],dtype=np.int8)
dy = np.array([0,  0, 1,  0, -1],dtype=np.int8)

# scores associés à chaque déplacement
ds = np.array([0,  1,  1,  1,  1],dtype=np.int8)

Debug = False
nb = 1 # nb de parties


def Simulate(Game):

    # on copie les datas de départ pour créer plusieurs parties en //
    G      = np.tile(Game.Grille,(nb,1,1))
    X      = np.tile(Game.PlayerX,nb)
    Y      = np.tile(Game.PlayerY,nb)
    S      = np.tile(Game.Score,nb)
    I      = np.arange(nb)  # 0,1,2,3,4,5...
    boucle = True
    if Debug : AffGrilles(G,X,Y)

    # VOTRE CODE ICI

    while(boucle) :
        if Debug :print("X : ",X)
        if Debug :print("Y : ",Y)
        if Debug :print("S : ",S)

        last_sum = np.sum(S)

        # marque le passage de la moto
        G[I, X, Y] = 2

        Vgauche = (G[I, X-1, Y] == 0) * 1
        Vhaut = (G[I, X, Y+1] == 0) * 1
        Vdroite = (G[I, X+1, Y] == 0) * 1
        Vbas = (G[I, X, Y-1] == 0) * 1

        Indices = np.zeros(nb,dtype=np.int32)
        LPossibles = np.zeros((nb,4),dtype=np.int32)
        # for i in range(nb):
        #     indice = 0
        #     if Vgauche[i] == 1:
        #         LPossibles[i,indice] = 1
        #         indice += 1
        #     if Vhaut[i] == 2:
        #         LPossibles[i,indice] = 2
        #         indice += 1
        #     if Vdroite[i] == 3:
        #         LPossibles[i,indice] = 3
        #         indice += 1
        #     if Vbas[i] == 4:
        #         LPossibles[i,indice] = 4
        #         indice += 1
        #     Indices[i] = indice
        #     for j in range(indice, 4):
        #         LPossibles[i][j] = 0
        LPossibles[I, Indices[I]] = Vgauche
        Indices[I] += Vgauche
        LPossibles[I, Indices[I]] = Vhaut*2
        Indices[I] += Vhaut
        LPossibles[I, Indices[I]] = Vdroite*3
        Indices[I] += Vdroite
        LPossibles[I, Indices[I]] = Vbas*4
        Indices[I] += Vbas
        Indices[Indices==0] = 1
        if Debug :print("LPossibles : ",LPossibles)
        if Debug :print("Indices : ",Indices)

        R = np.random.randint(12,size=nb)
        R[I] = R[I] % Indices[I]
        if Debug :print("R : ", R)

        # Direction : 2 = vers le haut
        Choix = np.ones(nb,dtype=np.uint8) * LPossibles[I,R[I]]
        S[I] += (LPossibles[I,R[I]] != 0)*1

        #DEPLACEMENT
        DX = dx[Choix]
        DY = dy[Choix]
        if Debug : print("DX : ", DX)
        if Debug : print("DY : ", DY)
        X += DX
        Y += DY


        #debug
        if Debug : AffGrilles(G,X,Y)
        if Debug : time.sleep(0)

        if np.sum(S) == last_sum:
            break
        else:
            last_sum = np.sum(S)

    if Debug :print("Scores : ",np.mean(S))
    return last_sum

def listeCoups(Game):
    L = []
    grille = Game.Grille
    x,y = Game.PlayerX, Game.PlayerY

    if (grille[x+1][y  ] == 0): L.append(( 1, 0))
    if (grille[x-1][y  ] == 0): L.append((-1, 0))
    if (grille[x  ][y+1] == 0): L.append(( 0, 1))
    if (grille[x  ][y-1] == 0): L.append(( 0,-1))
    if not L:
        L = [(0,0)]
    return L

# def SimulationPartie(Game):
#     Total = 0
#     while(True):
#         L = listeCoups(Game)
#         if L[0] == (0,0):
#             return Total
#         dx,dy = L[random.randrange(len(L))]
#         x,y = Game.PlayerX, Game.PlayerY
#         Game.Grille[x,y] = 2
#         x,y = x+dx, y+dy

#         Game.PlayerX = x
#         Game.PlayerY = y
#         Total += 1

# def MonteCarlo(Game, coup, nombreParties):
#     Total = 0
#     if(Game.Grille[Game.PlayerX+coup[0],Game.PlayerY+coup[1]] == 0):
#         for i in range(nombreParties):
#             Total+=1
#             Game2 = Game.copy()
#             Game2.PlayerX,Game2.PlayerY = Game.PlayerX+coup[0],Game.PlayerY+coup[1]
#             Total += SimulationPartie(Game2)
#     return Total

def MonteCarlo(Game, coup, nombreParties):
    global nb
    if(Game.Grille[Game.PlayerX+coup[0],Game.PlayerY+coup[1]] == 0):
        nb = nombreParties
        Game2 = Game.copy()
        Game2.PlayerX,Game2.PlayerY = Game.PlayerX+coup[0],Game.PlayerY+coup[1]
        return Simulate(Game2)
        

def Play(Game):   
    
    x,y = Game.PlayerX, Game.PlayerY
    # print(x,y)

    Game.Grille[x,y] = 2  # laisse la trace de la moto
    L = listeCoups(Game)
    if len(L) == 1:
        dx,dy = L[0][0], L[0][1]
    else:
        ScoresMC = []
        for c in L:
            ScoresMC.append(MonteCarlo(Game, c, 100000))
        coup = L[ScoresMC.index(max(ScoresMC))]
        dx,dy = coup[0], coup[1]
    x,y = x+dx, y+dy
    
    v = Game.Grille[x,y]
    
    if v > 0 :
        # collision détectée
        return True # partie terminée
    else :
       Game.PlayerX = x  # valide le déplacement
       Game.PlayerY = y  # valide le déplacement
       Game.Score += 1
       return False   # la partie continue
     

################################################################################
     
CurrentGame = GameInit.copy()
 

def Partie():
    Tstart = time.time()
    PartieTermine = Play(CurrentGame)
    print(time.time() - Tstart)
    if not PartieTermine :
        Affiche(CurrentGame)
        # rappelle la fonction Partie() dans 30ms
        # entre temps laisse l'OS réafficher l'interface
        Window.after(1,Partie) 
    else :
        AfficheScore(CurrentGame)


#####################################################################################
#
#  Mise en place de l'interface - ne pas toucher

AfficherPage(0)
Window.after(100,Partie)
Window.mainloop()