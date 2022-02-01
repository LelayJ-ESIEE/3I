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