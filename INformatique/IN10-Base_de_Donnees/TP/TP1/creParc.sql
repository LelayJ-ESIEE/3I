CREATE DATABASE parc;
USE parc;
CREATE TABLE parc.Segment(
    indIP VARCHAR(11) PRIMARY KEY,
    nomSegment VARCHAR(20) NOT NULL,
    etage TINYINT(1)
    );
CREATE TABLE parc.Salle(
    nSalle VARCHAR(7) PRIMARY KEY,
    nomSalle VARCHAR(20) NOT NULL,
    nbPoste TINYINT(2), indIP VARCHAR(11)
    );
CREATE TABLE parc.Poste(
    nPoste VARCHAR(7) PRIMARY KEY,
    nomPoste VARCHAR(20) NOT NULL,
    indIP VARCHAR(11),
    ad VARCHAR(3) CHECK(ad > "0" AND ad < "255"),
    typePoste VARCHAR(9),
    nSalle VARCHAR(7),
    );
CREATE TABLE parc.Logiciel(
    nLog VARCHAR(5) PRIMARY KEY,
    nomLog VARCHAR(20),
    dateAch dateTIME,
    version VARCHAR(7),
    typeLog VARCHAR(9),
    prix DECIMAL(6,2) CHECK(prix >= 0)
    );
CREATE TABLE parc.Installer(
    nPoste VARCHAR(7),
    nLog VARCHAR(5),
    numIns INTEGER(5) PRIMARY KEY,
    dateIns dateTIME DEFAULT CURRENT_TIMESTAMP,
    delai SMALLINT
    );
CREATE TABLE parc.Types(
    typeLP VARCHAR(9) PRIMARY KEY,
    nomType VARCHAR(20)
    );