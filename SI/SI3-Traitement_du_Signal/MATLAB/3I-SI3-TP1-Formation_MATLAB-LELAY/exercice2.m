% Genere les carres magiques de dimension d de 5 à 11 avec un pas de 2
%   dans les variables M{d}
function [M5,M7,M9,M11] = exercice2()
    for i=5:2:11
        s = sprintf('M%d = magic(%d);',i,i);   % Generation de l'expression
        eval(s);                               % Evaluation de l'expression
    end
end
