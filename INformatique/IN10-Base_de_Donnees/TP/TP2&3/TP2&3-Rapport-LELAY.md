# Base de données - TP2 et 3 - Rapport

## TP 2

### __creParc.sql__

```sql
...
CREATE TABLE parc.Installer(
    nPoste VARCHAR(7),
    nLog VARCHAR(5),
    numIns INTEGER(5) AUTO_INCREMENT PRIMARY KEY,
    dateIns dateTIME DEFAULT CURRENT_TIMESTAMP,
    delai SMALLINT
    );

```

### __insParc.sql__
```sql
USE parc;

INSERT INTO parc.Segment (indIP, nomSegment) VALUES
    ("130.120.80", "Brin RDC"),
    ("130.120.81", "Brin 1er étage"),
    ("130.120.82", "Brin 2e  étage");

INSERT INTO parc.Salle (nSalle, nomSalle, nbPoste, indIP) VALUES
    ("s01", "Salle 1", 3, "130.120.80"),
    ("s02", "Salle 2", 2, "130.120.80"),
    ("s03", "Salle 3", 2, "130.120.80"),
    ("s11", "Salle 11", 2, "130.120.81"),
    ("s12", "Salle 12", 1, "130.120.81"),
    ("s21", "Salle 21", 2, "130.120.82"),
    ("s22", "Salle 22", 0, "130.120.83"),
    ("s23", "Salle 23", 0, "130.120.83");

INSERT INTO parc.Poste (nPoste, nomPoste, indIP, ad, typePoste, nSalle) VALUES
    ("p1", "Poste 1", "130.120.80", "01", "TX", "s01"),
    ("p2", "Poste 2", "130.120.80", "02", "UNIX", "s01"),
    ("p3", "Poste 3", "130.120.80", "03", "TX", "s01"),
    ("p4", "Poste 4", "130.120.80", "04", "PCWS", "s02"),
    ("p5", "Poste 5", "130.120.80", "05", "PCWS", "s02"),
    ("p6", "Poste 6", "130.120.80", "06", "UNIX", "s03"),
    ("p7", "Poste 7", "130.120.80", "07", "TX", "s03"),
    ("p8", "Poste 8", "130.120.81", "01", "UNIX", "s11"),
    ("p9", "Poste 9", "130.120.81", "02", "TX", "s11"),
    ("p10", "Poste 10", "130.120.81", "03", "UNIX", "s12"),
    ("p11", "Poste 11", "130.120.82", "01", "PCNT", "s21"),
    ("p12", "Poste 12", "130.120.82", "02", "PCWS", "s21");

INSERT INTO parc.Logiciel (nLog, nomLog, dateAch, version, typeLog, prix) VALUES
    ("log1", "Oracle 6", 19950513, "6.2", "UNIX", 3000),
    ("log2", "Oracle 8", 19990915, "8i", "UNIX", 5600),
    ("log3", "SQL Server", 19980412, "7", "PCNT", 2700),
    ("log4", "Front Page", 19970603, "5", "PCWS", 500),
    ("log5", "WinDev", 19970512, "5", "PCWS", 750),
    ("log6", "SQL*NET", NULL, "2.0", "UNIX", 500),
    ("log7", "I. I. S.", 20020412, "2", "PCNT", 810),
    ("log8", "DreamWeaver", 20030921, "2.0", "BeOS", 1400);

INSERT INTO parc.Types (typeLP, nomType) VALUES
    ("TX", "Terminal X-Window"),
    ("UNIX", "Système Unix"),
    ("PCNT", "PC Windows  NT"),
    ("PCWS", "PC Windows"),
    ("NC", "Network Computer");

INSERT INTO parc.Installer (nPoste, nLog, dateIns) VALUES
    ("p2", "log1", 20030515),
    ("p2", "log2", 20030917),
    ("p4", "log5", NULL),
    ("p6", "log6", 20030520),
    ("p6", "log1", 20030520),
    ("p8", "log2", 20030519),
    ("p8", "log6", 20030520),
    ("p11", "log3", 20030420),
    ("p12", "log4", 20030420),
    ("p11", "log7", 20030420),
    ("p7", "log7", 20030401);
```

### __modification.sql__

```sql
USE parc;

UPDATE parc.Segment SET etage=0 WHERE indIP="130.120.80";
UPDATE parc.Segment SET etage=1 WHERE indIP="130.120.81";
UPDATE parc.Segment SET etage=2 WHERE indIP="130.120.82";

UPDATE parc.Logiciel SET prix=prix*0.9 WHERE typeLog="PCNT";
```

## TP 3

### __évolution.sql__

```sql
ALTER TABLE Segment ADD nbSalle TINYINT(2) DEFAULT 0;
ALTER TABLE Segment ADD nbPoste TINYINT(2) DEFAULT 0;
ALTER TABLE Logiciel ADD nbInstall TINYINT(2) DEFAULT 0;
ALTER TABLE Poste ADD nbLog TINYINT(2) DEFAULT 0;

ALTER TABLE Salle MODIFY nomSalle VARCHAR(30);
ALTER TABLE Segment MODIFY nomSegment VARCHAR(15);
ALTER TABLE Segment MODIFY nomSegment VARCHAR(14);

ALTER TABLE Installer ADD UNIQUE u_Installer_nPoste_nLog (nPoste, nLog);
ALTER TABLE Poste ADD FOREIGN KEY fk_Poste_indIP_Segment (indIP) REFERENCES Segment(indIP);
ALTER TABLE Poste ADD FOREIGN KEY fk_Poste_typePoste_Types (typePoste) REFERENCES Types(typeLP);
ALTER TABLE Poste ADD FOREIGN KEY fk_Poste_nSalle_Salle (nSalle) REFERENCES Salle(nSalle);
ALTER TABLE Installer ADD FOREIGN KEY fk_Installer_nPoste_Poste (nPoste) REFERENCES Poste(nPoste);
ALTER TABLE Installer ADD FOREIGN KEY fk_Installer_nLog_Logiciel (nLog) REFERENCES Logiciel(nLog);

DELETE FROM Salle WHERE indIP NOT IN (SELECT indIP FROM Segment);
INSERT INTO Types (typeLP, nomType) VALUE ("BeOS", "Système Be");
ALTER TABLE Salle ADD FOREIGN KEY fk_Salle_indIP_Segment (indIP) REFERENCES Segment(indIP);
ALTER TABLE Logiciel ADD FOREIGN KEY fk_Logiciel_typeLog_Types (typeLog) REFERENCES Types(typeLP);
```

### __dropParc.sql__

```sql
USE parc;
DROP TABLE Installer;
DROP TABLE Logiciel;
DROP TABLE Poste;
DROP TABLE Salle;
DROP TABLE Segment;
DROP TABLE Types;
DROP DATABASE parc;
```
