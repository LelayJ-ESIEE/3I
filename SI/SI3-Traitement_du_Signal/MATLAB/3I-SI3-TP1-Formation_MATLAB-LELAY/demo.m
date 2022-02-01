% Demonstration de l'exercice 1
X = linspace(-10,10);
Y = arrayfun(@(x) exercice1(x),X);
figure;
plot(X,Y)
title("Démonstration de l'exercice 1 : sinc(x) pour x entre -10 et 10")
grid

% Demonstration de l'exercice 2
disp(" ")
disp("Demonstration de l'exercice 2 :")
disp(" ")

[M5,M7,M9,M11]=exercice2();                         % Generation des carrés

for i=5:2:11                                        % Pour i 5->11 (pas: 2)
    s = sprintf('disp("M%d =") \n disp(M%d)',i,i);  %   s = M{i} = {M{i}}
    eval(s);                                        % Afficher s
end                                                 % Fin pour

% demonstration de l'exercice 3
X = linspace(eps('double'),1);
Y = arrayfun(@(x) exercice3(x),X);
figure;
plot(X,Y)
title("Démonstration de l'exercice 3")
grid
