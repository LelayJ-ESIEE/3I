import torch, numpy, matplotlib.pyplot as plt

layer1 = torch.nn.Linear(1,3)
layer2 = torch.nn.Linear(3,1)
relu  = torch.nn.ReLU()

Lx = numpy.linspace(-4,4,150)
Lx = torch.FloatTensor(Lx)   	# crée un tenseur de taille 50

Lx = Lx.reshape(150,1)		    # change la taille du tenseur pour (50,1)
Ly = layer1(Lx)			        # calcule pour chaque xi la sortie du neurone 1
Ly = relu(Ly)                   # fonction d'activation
Lz = layer2(Ly)			        # calcule pour chaque xi la sortie du neurone 2
Lz = relu(Lz)                   # fonction d'activation
Lz = Lz.detach() 			    # extrait un tenseur du réseau
Lz = Lz.numpy()			        # conversion vers un tableau numpy

plt.plot(Lx,Lz,'.') 		    # affichage
plt.axis('equal') 		        # repère orthonormé
plt.show() 			            # ouvre la fenetre d'affichage
