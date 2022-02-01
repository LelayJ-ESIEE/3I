# Base de données - TP4 - Rapport

## __creDynamique.sql__

```sql
CREATE TABLE Softs AS (
    SELECT
        nomLog AS nomSoft,
        version,
        prix
    FROM parc.Logiciel);

CREATE TABLE PCSeuls AS (
    SELECT
        nPoste AS nP,
        nomPoste AS nomP,
        indIP AS seq,
        ad,
        typePoste AS typeP,
        nSalle AS salle
    FROM parc.Poste
    WHERE typePoste LIKE 'PC%');
```

## __requetes.sql__
```sql
SELECT typePoste AS typeP8 FROM Poste WHERE nPoste = 'p8';
SELECT nomLog AS logicielsUnix FROM Logiciel WHERE typeLog = 'UNIX';
SELECT nomPoste, CONCAT(indIP, '.', ad) AS adresseIP, nSalle FROM Poste WHERE typePoste IN ('UNIX', 'PCWS');
SELECT nomPoste, CONCAT(indIP, '.', ad) AS adresseIP, nSalle FROM Poste WHERE indIP = '130.120.80' ORDER BY nSalle DESC;
SELECT nLog AS logicielsOnP6 FROM Installer WHERE nPoste = 'p6';
SELECT nPoste AS postesWithLog1Installed FROM Installer WHERE nLog = 'log1';
SELECT nomPoste AS PostesTX, CONCAT(indIP, '.', ad) AS adresseIP FROM Poste WHERE typePoste = 'TX';
SELECT nPoste, COUNT(DISTINCT nLog) AS nbLogiciels FROM Installer GROUP BY nPoste;
SELECT nSalle, COUNT(DISTINCT nPoste) AS nbPostes FROM Poste GROUP BY nSalle;
SELECT nLog, COUNT(DISTINCT nPoste) AS nbPostes FROM Installer GROUP BY nLog;
SELECT AVG(prix) AS averagePrixLogiciel FROM Logiciel WHERE typeLog = 'UNIX';
SELECT MAX(dateAch) AS lastAchatDate FROM Logiciel;
SELECT nPoste AS postesWith2LogsInstalled FROM Installer GROUP BY nPoste HAVING COUNT(DISTINCT nLog) = 2;
SELECT nPoste AS postesWith2LogsInstalled FROM (SELECT nPoste, COUNT(DISTINCT nLog) AS nbLogiciels FROM Installer GROUP BY nPoste) as tmp WHERE nbLogiciels = 2;
SELECT typeLP AS noPosteType FROM Types WHERE typeLP NOT IN (SELECT typePoste FROM Poste);
SELECT typeLP AS PosteAndLogType FROM Types WHERE typeLP IN (SELECT typePoste FROM Poste WHERE typePoste IN (SELECT typeLog FROM Logiciel));
SELECT typePoste as typePosteExclusive FROM Poste WHERE typePoste NOT IN (SELECT typeLog FROM Logiciel) GROUP BY typePoste;
SELECT CONCAT(indIP, '.', ad) AS adresseIP FROM Poste WHERE nPoste IN (SELECT nPoste FROM Installer WHERE nLog = 'log6');
SELECT CONCAT(indIP, '.', ad) AS adresseIP FROM Poste WHERE nPoste IN (SELECT nPoste FROM Installer WHERE nLog IN (SELECT nLog FROM Logiciel WHERE nomLog = 'Oracle 8'));
SELECT nomSegment FROM Segment WHERE indIP IN (SELECT indIP FROM Poste WHERE typePoste = 'TX' GROUP BY indIP HAVING COUNT(DISTINCT nPoste) = 3);
SELECT nomSalle FROM Salle WHERE nSalle IN (SELECT nSalle FROM Poste WHERE nPoste IN (SELECT nPoste FROM Installer WHERE nLog IN (SELECT nLog FROM Logiciel WHERE nomLog = 'Oracle 6')));
SELECT nomLog FROM Logiciel WHERE dateAch IN (SELECT MAX(dateAch) AS lastAchatDate FROM Logiciel);
SELECT CONCAT(indIP, '.', ad) AS adresseIP FROM Poste, Installer WHERE Poste.nPoste = Installer.nPoste AND nLog = 'log6';
SELECT CONCAT(indIP, '.', ad) AS adresseIP FROM Poste, Installer, Logiciel WHERE Poste.nPoste = Installer.nPoste AND Installer.nLog = Logiciel.nLog AND nomLog = 'Oracle 8';
SELECT nomSegment FROM Segment, Poste WHERE Segment.indIP = Poste.indIP AND typePoste = 'TX' GROUP BY Poste.indIP HAVING COUNT(DISTINCT nPoste) = 3;
SELECT nomSalle FROM Salle, Poste, Installer, Logiciel WHERE Salle.nSalle = Poste.nSalle AND Poste.nPoste = Installer.nPoste AND Installer.nLog = Logiciel.nLog AND nomLog = 'Oracle 6';
SELECT nomSegment, nomSalle, adresseIP, COUNT(*) FROM (SELECT nomSegment, nomSalle, CONCAT(Poste.indIP, '.', Poste.ad) AS adresseIP, nomLog, dateIns FROM Segment, Salle, Poste, Logiciel, Installer WHERE Segment.indIP = Poste.indIP AND Poste.nSalle = Salle.nSalle AND Poste.nPoste = Installer.nPoste AND Installer.nLog = Logiciel.nLog) AS tmp GROUP BY nomSegment, nomSalle, adresseIP;
SELECT CONCAT(indIP, '.', ad) AS adresseIP FROM Poste NATURAL JOIN Installer WHERE nLog = 'log6';
SELECT CONCAT(indIP, '.', ad) AS adresseIP FROM Poste NATURAL JOIN Installer NATURAL JOIN Logiciel WHERE nomLog = 'Oracle 8';
SELECT nomSegment FROM Segment NATURAL JOIN Poste WHERE typePoste = 'TX' GROUP BY Poste.indIP HAVING COUNT(DISTINCT nPoste) = 3;
SELECT nomSalle FROM Salle NATURAL JOIN Poste NATURAL JOIN Installer NATURAL JOIN Logiciel WHERE nomLog = 'Oracle 6';
SELECT nomPoste FROM Poste AS P WHERE (SELECT COUNT(*) FROM Installer WHERE nPoste = P.nPoste AND nLog IN (SELECT nLog FROM Installer WHERE nPoste = 'p6')) > 0 AND nPoste != 'p6';
SELECT nomPoste FROM Poste AS P WHERE NOT EXISTS (SELECT nLog FROM Installer WHERE nPoste = 'p6' AND nLog NOT IN (SELECT nLog FROM Installer WHERE nPoste = P.nPoste)) AND nPoste != 'p6';
SELECT nomPoste FROM Poste AS P WHERE NOT EXISTS (SELECT nLog FROM Installer WHERE nPoste = 'p2' AND nLog NOT IN (SELECT nLog FROM Installer WHERE nPoste = P.nPoste)) AND NOT EXISTS (SELECT nLog FROM Installer WHERE nPoste = P.nPoste AND nLog NOT IN (SELECT nLog FROM Installer WHERE nPoste = 'p2')) AND nPoste != 'p2';
```

## __modifSynchronisees.sql__

```sql
INSERT INTO parc.Installer (nPoste, nLog, dateIns) VALUES
    ("p2", "log6", SYSDATE()),
    ("p8", "log1", SYSDATE()),
    ("p10", "log1", SYSDATE());

UPDATE Segment SET nbSalle = (SELECT COUNT(*) FROM Salle WHERE Segment.indIP = Salle.indIP);
UPDATE Segment SET nbPoste = (SELECT COUNT(*) FROM Poste WHERE Segment.indIP = Poste.indIP);
UPDATE Logiciel SET nbInstall = (SELECT COUNT(*) FROM Installer WHERE Installer.nLog = Logiciel.nLog);
UPDATE Poste SET nbLog = (SELECT COUNT(*) FROM Installer WHERE Poste.nPoste = Installer.nPoste);
```