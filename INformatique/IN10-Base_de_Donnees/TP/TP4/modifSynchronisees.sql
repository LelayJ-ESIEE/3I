INSERT INTO parc.Installer (nPoste, nLog, dateIns) VALUES
    ("p2", "log6", SYSDATE()),
    ("p8", "log1", SYSDATE()),
    ("p10", "log1", SYSDATE());

UPDATE Segment SET nbSalle = (SELECT COUNT(*) FROM Salle WHERE Segment.indIP = Salle.indIP);
UPDATE Segment SET nbPoste = (SELECT COUNT(*) FROM Poste WHERE Segment.indIP = Poste.indIP);
UPDATE Logiciel SET nbInstall = (SELECT COUNT(*) FROM Installer WHERE Installer.nLog = Logiciel.nLog);
UPDATE Poste SET nbLog = (SELECT COUNT(*) FROM Installer WHERE Poste.nPoste = Installer.nPoste);