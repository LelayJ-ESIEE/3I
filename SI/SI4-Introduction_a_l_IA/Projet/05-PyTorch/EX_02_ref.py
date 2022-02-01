import numpy as np
import random, math
import torch.nn as nn
import torch

# courbe d'origine
xmin      =  -math.pi
xmax      =   math.pi
nbpt      =  100

Lx = np.linspace(xmin,xmax, nbpt)
Ly = np.empty(nbpt)
for i in range(nbpt):
    Ly[i] = math.cos(Lx[i])

# création du réseau

layer1 =  nn.Linear(1,10)
relu1  =  nn.ReLU()
layer2 =  nn.Linear(10,1)
loss   =  nn.MSELoss()
for t in layer1.parameters() : print(t)

# création des tenseurs

input_tensor  = torch.FloatTensor(Lx)
input_tensor = input_tensor.reshape((nbpt,1))

output_tensor = torch.FloatTensor(Ly)
output_tensor = output_tensor.reshape((nbpt,1))

# apprentissage et gradient descent
pas = 0.005
LResults = []
err  = 1000
iter = 0

while err > 0.001  and iter < 20000 :

    # reinitialise la valeur du gradient
    layer1.zero_grad()
    layer2.zero_grad()

    # passe FORWARD
    v = layer1(input_tensor)
    v = relu1(v)
    v = layer2(v)

    erreur = loss(v,output_tensor)
    err = erreur.item()

    # passe BACKWARD
    erreur.backward()

    # gradient descent W -= grad * pas
    layer1.weight.data -= layer1.weight.grad * pas
    layer2.weight.data -= layer2.weight.grad * pas

    # mmonitoring
    iter += 1
    if iter % 1000 == 0 : print("It: ",iter, " " ,err)
    if iter % 100 == 0 :
        Ry = v.detach().reshape(nbpt).numpy()
        LResults.append((Ry,iter))


#  Affichage et Animation
import matplotlib.animation as animation
import matplotlib.pyplot as plt
fig, ax = plt.subplots()
Trace1  = ax.plot(Lx, np.sin(Lx))[0]
Trace2  = ax.plot(Lx, np.cos(Lx),'.')[0]
info    = ax.text( -1,-0.75, 'an equation ', fontsize=15)

def animate(i):
    i = i % len(LResults)
    Trace1.set_ydata(LResults[i][0])
    info.set_text('Iteration ' + str(LResults[i][1]))
    return Trace1, info

ani = animation.FuncAnimation(fig, animate, interval=50, blit=True)
plt.show()
