import tkinter as tk
from tkinter import messagebox
import random
import numpy as np
import time

###############################################################################
# création de la fenetre principale  - ne pas toucher

LARG = 300
HAUT = 500

Window = tk.Tk()
Window.geometry(str(LARG)+"x"+str(HAUT))   # taille de la fenetre
Window.title("ESIEE - Morpion")


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

canvas = tk.Canvas(Frame0,width = LARG, height = HAUT, bg ="black" )
canvas.place(x=0,y=0)


#################################################################################
#
#  Parametres du jeu
 
Grille = [ [0,0,0], 
           [0,0,0], 
           [0,0,0] ]  # attention les lignes représentent les colonnes de la grille
           
Grille = np.array(Grille)
Grille = Grille.transpose()  # pour avoir x,y

SCORES = [0,0]   # score du joueur 1 (Humain) et 2 (IA)

GAME_BEGINNING = True

###############################################################################
#
# gestion des pions

def Play_J(ID, x,y):
    global Grille

    Grille[x][y] = ID

def Unplay(x,y):
    global Grille
    
    Grille[x][y] = 0

###############################################################################
#
# gestion du joueur humain et de l'IA
# VOTRE CODE ICI 

def Random_Case():
    cases = Empty_Cases()
    if len(cases) != 0:
        return cases[random.randrange(len(cases))]
    return 0

def Game_Ended():
    return (Winning_Config()+Tie_Config() != 0)

def Score_Calc():
    winner = Winning_Config()
    if winner == 1:
        return ((1,0),None)
    if winner == 2:
        return ((0,1),None)
    return ((0,0), None)

def Simulate_Player(ID):
    if Game_Ended():
        return Score_Calc()
    cases = Empty_Cases()
    res = []
    for hit in cases:
        Play_J(ID, hit[0], hit[1])
        score = Simulate_Player(ID%2+1)[0]
        res.append((score, hit))
        Unplay(hit[0], hit[1])
    gains = [Gain(Ret[0], ID) for Ret in res]
    return res[gains.index(max(gains))]

def Gain(Score, ID):
    return Score[ID-1]-Score[ID%2]
    
################################################################################
#    
# Dessine la grille de jeu

def Dessine(PartieGagnee = False):
        ## DOC canvas : http://tkinter.fdex.eu/doc/caw.html
        canvas.delete("all")
        
        for i in range(4):
            canvas.create_line(i*100,0,i*100,300,fill="blue", width="4" )
            canvas.create_line(0,i*100,300,i*100,fill="blue", width="4" )
            
        for x in range(3):
            for y in range(3):
                xc = x * 100 
                yc = y * 100 
                if ( Grille[x][y] == 1):
                    canvas.create_line(xc+10,yc+10,xc+90,yc+90,fill="red", width="4" )
                    canvas.create_line(xc+90,yc+10,xc+10,yc+90,fill="red", width="4" )
                if ( Grille[x][y] == 2):
                    canvas.create_oval(xc+10,yc+10,xc+90,yc+90,outline="yellow", width="4" )

        msg = 'SCORES : ' + str(SCORES[0]) + '-' + str(SCORES[1])
        fillcoul = 'gray'
        if (PartieGagnee) :
            fillcoul = ['red','yellow','white'][PartieGagnee - 1]
            for i in range(4):
                canvas.create_line(i*100,0,i*100,300,fill=fillcoul, width="4" )
                canvas.create_line(0,i*100,300,i*100,fill=fillcoul, width="4" )
        canvas.create_text(150,400, font=('Helvetica', 30), text = msg, fill=fillcoul)  

        canvas.update()
        
       
        
  
####################################################################################
#
#  fnt appelée par un clic souris sur la zone de dessin

def MouseClick(event):
   
    Window.focus_set()
    x = event.x // 100  # convertit une coordonée pixel écran en coord grille de jeu
    y = event.y // 100
    if ( (x<0) or (x>2) or (y<0) or (y>2) or Grille[x][y] != 0) : return
     
    if GAME_BEGINNING:
        Reset_Game() 
    
    # print("clicked at", x,y)
    Play_J(1, x, y)  # gestion du joueur humain et de l'IA

    game_state = Winning_Config() + Tie_Config()
    if game_state:
        End_Game(game_state)
    
    case = Simulate_Player(2)
    Play_J(2, case[1][0], case[1][1])

    game_state = Winning_Config() + Tie_Config()
    if game_state:
        End_Game(game_state)
    
    Dessine()
    
canvas.bind('<ButtonPress-1>',    MouseClick)

###############################################################################
#
# gestion de l'etat du jeu

def Reset_Game():
    global Grille,GAME_BEGINNING

    Grille = [[0 for i in range(3)] for j in range(3)]
    Dessine()
    GAME_BEGINNING = False

def Empty_Cases():
    global Grille

    return [(x,y) for x in range(3) for y in range(3) if Grille[x][y] == 0]

def Winning_Config():
    global Grille
    
    for i in (1,2):
        if [i,i,i] in Grille:
            return i
        for y in range(3):
                if (Grille[0][y] == Grille[1][y] == Grille[2][y] == i) :
                    return i
    if Grille[1][1] != 0 and ( Grille[0][0] == Grille[1][1] == Grille[2][2] or Grille[0][2] == Grille[1][1] == Grille[2][0]):
        return Grille[1][1]
    return 0

def Tie_Config():
    if (len(Empty_Cases()) == 0) and not Winning_Config() :
        return 3
    return 0

def End_Game(Winner):
    global GAME_BEGINNING

    GAME_BEGINNING = True
    if Winner%3 != 0:
        SCORES[Winner-1] += 1
    Dessine(Winner)
    time.sleep(1)
    Reset_Game()

#####################################################################################
#
#  Mise en place de l'interface - ne pas toucher

AfficherPage(0)
Dessine()
Window.mainloop()
