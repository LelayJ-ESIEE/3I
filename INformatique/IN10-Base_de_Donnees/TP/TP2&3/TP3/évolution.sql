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