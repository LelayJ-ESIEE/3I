% Calcule la somme des inverses des carres des entiers naturels tant que
%   celui-ci est supérieur à l'argument epsilon passé en paramètre
function y = exercice3(epsilon)
    arguments
        epsilon double {mustBePositive}
    end
    n=1;                    % Initialisation de n à 1
    i_n_sq = 1/(n^2);       % Calcul de l'inverses du carre de n
    y=0;                    % Initialisation du résultat à 0

    while i_n_sq > epsilon  % Tant que 1/n^2 < espsilon
        y = y + i_n_sq;     %   Ajouter 1/n^2 à y
        n = n + 1;          %   Incrementer n
        i_n_sq = 1/n^2;     %   Calculer l'inverses du carre de n
    end                     % Fin tant que
end
