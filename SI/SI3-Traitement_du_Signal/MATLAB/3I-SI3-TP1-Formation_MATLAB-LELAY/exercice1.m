% Calcule du sinus cardinal d'un scalaire (1 si 0, sin(x)/x sinon)
function y = exercice1(x)
    arguments
        x double
    end

    if x == 0           % Si x=0
        y = 1;          %   sinc(x) = lim(sin(x)/x, x->0) = 1 retourne
    else                % Sinon
        y = sin(x)/x;   %   sinc(x) = sin(x)/x retourne
    end                 % Fin si
end
