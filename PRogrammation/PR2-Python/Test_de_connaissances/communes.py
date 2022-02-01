"""
Module d'évaluation de début d'unité
"""

# Vos import ici
import csv
import collections

def read_file(filename): # Line 22 : Inutile (?) : dict maintient l'ordre depuis Python 3.6
    """
    filename : nom du fichier csv

    Retourne une liste de dictionnaires dont les clés sont définies par
    la 1ere ligne du fichier

    >>> data = read_file("communes.csv")
    >>> type(data)
    <class 'list'>
    >>> len(data)
    36683
    >>> type(data[0])
    <class 'collections.OrderedDict'>
    >>> len(data[0])
    10
    >>> data[0]["Nom de la région"]
    'Rhône-Alpes'
    >>> data[0]["Code département"]
    '01'
    >>> data[0]["Code canton"]
    '08'
    >>> data[0]["Nom de la commune"]
    "L' Abergement-Clémenciat"
    >>> data[0]["Population totale"]
    '780'
    >>> data[34878]["Nom de la région"]
    'Limousin'
    >>> data[34878]["Code département"]
    '87'
    >>> data[34878]["Code canton"]
    '99'
    >>> data[34878]["Nom de la commune"]
    'Limoges'
    >>> data[34878]["Population totale"]
    '137 473'
    """
    data = []

    with open(filename, mode='r', encoding='utf8') as fichier:
        reader = csv.DictReader(fichier, delimiter=';')
        for line in reader:
            data.append(collections.OrderedDict(line))
    return data

def build_set_departements(data):
    """
    data : la liste de dictionnaires retournée par read_file()

    Retourne l'ensemble des départements (set)
    >>> data = read_file("communes.csv")
    >>> sd = build_set_departements(data)
    >>> type(sd)
    <class 'set'>
    >>> len(sd)
    100
    >>> '15' in sd
    True
    >>> 15 in sd
    False
    >>> 'Cantal' in sd
    False
    >>> '2A' in sd
    True
    >>> '2B' in sd
    True
    >>> 'Corse' in sd
    False
    >>> '20' in sd
    False
    """
    # votre code ici
    set_departement = set()

    for line in data:
        if not line["Code département"] in set_departement:
            set_departement.add(line["Code département"])

    return set_departement

def build_list_communes(data):
    """
    data : la liste de dictionnaires retournée par read_file()

    Retourne la liste des tuples (commune, département, population)
    >>> data = read_file("communes.csv")
    >>> lc = build_list_communes(data)
    >>> type(lc)
    <class 'list'>
    >>> len(lc)
    36683
    >>> type(lc[999])
    <class 'tuple'>
    >>> len(lc[999])
    3
    >>> lc[999]
    ('Pargny-les-Bois', '02', 131)
    >>> type(lc[999][0])
    <class 'str'>
    >>> type(lc[999][1])
    <class 'str'>
    >>> type(lc[999][2])
    <class 'int'>
    >>> lc[100:102]
    [('Cize', '01', 181), ('Cleyzieu', '01', 140)]
    >>> lc[34878]
    ('Limoges', '87', 137473)
    """
    # votre code ici
    list_communes = [
                        (
                        line["Nom de la commune"],
                        line["Code département"],
                        int(line["Population totale"].replace(" ",""))
                        )
                    for line in data
                    ]

    return list_communes

def build_dict_departements(list_communes, set_departement):
    """
    lc : la liste des communes retournée par build_list_communes()
    sd : l'ensemble des départements retourné par build_set_departements()

    Retourne un dictionnaire dont la clé est le département
    et la valeur une liste [nombre de communes, population totale]
    >>> data = read_file("communes.csv")
    >>> sd = build_set_departements(data)
    >>> lc = build_list_communes(data)
    >>> dd = build_dict_departements(lc, sd)
    >>> type(dd)
    <class 'dict'>
    >>> len(dd)
    100
    >>> dd['18']
    [290, 319693]
    >>> dd['21']
    [706, 543648]
    >>> dd['27']
    [675, 612518]
    >>> dd['53']
    [261, 318095]
    """
    # votre code ici
    dict_departements = {dept : [0,0] for dept in set_departement}
    for commune in list_communes:
        dict_departements[commune[1]][0] += 1
        dict_departements[commune[1]][1] += commune[2]
    return dict_departements

def stat_by_dpt(dict_departements, dpt):
    """
    dd : le dictionnaire retourné par build_dict_departements()
    dpt : le département concerné (str)

    Retourne une liste [nombre de communes, population totale]
    >>> data = read_file("communes.csv")
    >>> sd = build_set_departements(data)
    >>> lc = build_list_communes(data)
    >>> dd = build_dict_departements(lc, sd)
    >>> sbd = stat_by_dpt(dd, '87')
    >>> type(sbd)
    <class 'list'>
    >>> len(sbd)
    2
    >>> sbd[1]
    384411
    >>> sbd[0]
    201
    >>> sbd = stat_by_dpt(dd, '77')
    >>> sbd[1]
    1387830
    >>> sbd[0]
    513
    >>> sbd = stat_by_dpt(dd, 'Corse')
    >>> sbd is None
    True
    """
    # votre code ici
    try:
        return dict_departements[dpt]
    except KeyError:
        return None

def main():
    """
    Méthode main, utilisée pour les tests
    """
    # votre code de test ici
    # le code ci dessous est exécuté avec la commande :
    #   python communes.py

# Ne pas modifier le code ci-dessous
if __name__ == '__main__':
    main()
