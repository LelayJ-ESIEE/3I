# Représentation de la grille. 0 : arrivée ; 1 : libre; 2 : départ, 3 : mur
grille = """3333333333
3131111113
3231113313
3111113313
3333313313
3333313113
3333333113
3131111113
3111111133
3333033333"""
# Dictionnaire des valeurs de substitution
d = {'0' : '0x00', '1' : '0xFE' , '2' : "0xFE", '3' : "0xFF"}

def values(grille):
    lines = grille.split("\n")
    x=0
    y=0
    largeur = len(lines[0])
    hauteur = len(lines)
    l = []
    for line in lines:
        for c in line:
            l.append(d[c])
            if c == "2":
                x = line.index(c)
                y = lines.index(line)
    cases = ", ".join(l)


    s = """        AREA    CONSTANTES, DATA, READONLY
X       DCB        {0}
Y       DCB        {1}
LARGEUR DCB        {2}
HAUTEUR DCB        {3}
        AREA    GRILLE, DATA, READWRITE
CASES   DCB        {4}""".format(x,y,largeur,hauteur,cases)

    print(s)

if __name__ == "__main__":
    values(grille)