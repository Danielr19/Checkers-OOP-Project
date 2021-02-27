# -*- coding: utf-8 -*-
"""
Created on Sat Jul 11 18:41:56 2020

@author: Hijos
"""
from Ficha import Ficha
from CasillaNegra import CasillaNegra
from FichaNegra import FichaNegra
from FichaBlanca import FichaBlanca
from ReinaNegra import ReinaNegra
from ReinaBlanca import ReinaBlanca
class Tablero:
    
    def __init__(self):
         c = 8
         r = 8
         self.__casillas = [ [Ficha(i,j).Representacion for j in range (c) ] for i in range(r)]
         self.__Raw= [ [Ficha(i,j) for j in range (c) ] for i in range(r)]
        
        # tablero = [8][8]
        # for i in range(8):
        #     for j in range (8):
        #        tablero[i][j] = Ficha(i,j).Representacion
        # self.__casillas = tablero
    
    @property
    def Casillas (self):
        return self.__casillas
    @property
    def Raw(self):
        return self.__Raw
    
    def __getitem__(self, i, j):
        return self.__casillas[i][j]
    def __str__(self):
        return self.__casillas
    def Inicio(self):
        
            # Poner las casillas negras
            for i in range(8):
            
                for j in range(8):
                
                    if(( i==0 or i==2 or i == 4 or i == 6) and (j==1 or j==3 or j==5 or j== 7)):
                    
                        self.__casillas[i][j] =  CasillaNegra(i,j).Representacion  
                        self.__Raw[i][j] =  CasillaNegra(i,j) 
                    elif((i == 1 or i == 3 or i == 5 or i == 7) and (j==0 or j == 2 or j == 4 or j == 6)):
                    
                        self.__casillas[i][j] =  CasillaNegra(i,j).Representacion 
                        self.__Raw[i][j] =  CasillaNegra(i,j)
    def ColocarFichas(self):
         # # Poner las fichas negras en su posicion inicial
             for i in range(3):
            
                for j in range(8):
                
                     if(( i==0 or i==2 ) and (j==1 or j==3 or j==5 or j== 7)):
                    
                         self.__casillas[i][j] =  FichaNegra(i,j).Representacion
                         self.__Raw[i][j] =  FichaNegra(i,j)
                    
                     elif((i == 1) and (j==0 or j == 2 or j == 4 or j == 6)):
                    
                         self.__casillas[i][j] =  FichaNegra(i,j).Representacion
                         self.__Raw[i][j] =  FichaNegra(i,j)
                    
                   
                
            

          #   # Poner las fichas blancas en su posición inicial
             for i in range(5,8):
            
                 for j in range (8):
                
                     if ((i == 5 or i == 7) and (j == 0 or j == 2 or j == 4 or j == 6)):
                    
                         self.__casillas[i][j] =  FichaBlanca(i,j).Representacion
                         self.__Raw[i][j] =  FichaBlanca(i,j)
                    
                     elif((i == 6) and (j == 1 or j == 3 or j == 5 or j == 7)):
                    
                         self.__casillas[i][j] = FichaBlanca(i,j).Representacion
                         self.__Raw[i][j] = FichaBlanca(i,j)
                         
                               
    def Refresh(self,F,C,f,c,Validacion1,Validacion2,jugador):
     valcor = []
     v = []
     if Validacion1 == 0:
                        # arriba o abajo?
            if f - F < 0:
                g = F-1
                if c -C < 0: # izquierda o derecha?
                    h = C -1
                else:
                    h = C+1
            else: 
                g = F+1
                if c -C < 0: # izquierda o derecha?
                    h = C -1
                else:
                    h = C+1
            if self.__Raw[g][h].colorbase != jugador.color and self.__Raw[g][h].colorbase != 'black' and  self.__Raw[g][h].colorbase != '  ':   
                self.__casillas[g][h] =  CasillaNegra(g,h).Representacion       
                self.__Raw[g][h] =  CasillaNegra(g,h)   
                valcor2 = []
                v2 = []
                for elem in Validacion2:
                    valcor2.extend(str(elem.fila))
                    valcor2.extend(str(elem.columna))
                    v2.append([valcor2.pop(0),valcor2.pop(0)])
                tabicor2 = []    
                tabicor2.extend(str(self.__Raw[f][c].fila ))
                tabicor2.extend(str(self.__Raw[f][c].columna))
                q = v2.index(tabicor2)
                self.__casillas[f][c] = Validacion2[q].Representacion
                self.__casillas[F][C] = CasillaNegra(F,C).Representacion
                self.__Raw[f][c] = Validacion2[q]
                self.__Raw[F][C] = CasillaNegra(F,C)
                if self.__Raw[f][c].colorbase == 'blanca' and self.__Raw[f][c].fila == 0:
                    self.__casillas[f][c] = ReinaBlanca(f,c).Representacion
                    self.__Raw[f][c] = ReinaBlanca(f,c)
            
                elif self.__Raw[f][c].colorbase == 'negra' and self.__Raw[f][c].fila == 7:
                    self.__casillas[f][c] = ReinaNegra(f,c).Representacion
                    self.__Raw[f][c] = ReinaNegra(f,c)
                
                    

                puntaje = 1 
            else:
                raise Exception('Jugada no válida')
                      
     else:    
        for elem in Validacion1:
            valcor.extend(str(elem.fila))
            valcor.extend(str(elem.columna))
            v.append([valcor.pop(0),valcor.pop(0)])
        tabicor = []    
        tabicor.extend(str(self.__Raw[f][c].fila))
        tabicor.extend(str(self.__Raw[f][c].columna))
  
        if v.count(tabicor) !=0: 
            k = v.index(tabicor)
            self.__casillas[f][c] = Validacion1[k].Representacion
            self.__casillas[F][C] = CasillaNegra(F,C).Representacion
            self.__Raw[f][c] = Validacion1[k]
            self.__Raw[F][C] = CasillaNegra(F,C)
            if self.__Raw[f][c].colorbase == 'blanca' and self.__Raw[f][c].fila == 0:
                self.__casillas[f][c] = ReinaBlanca(f,c).Representacion
                self.__Raw[f][c] = ReinaBlanca(f,c)
            
            elif self.__Raw[f][c].colorbase == 'negra' and self.__Raw[f][c].fila == 7:
                self.__casillas[f][c] = ReinaNegra(f,c).Representacion
                self.__Raw[f][c] = ReinaNegra(f,c)
            puntaje = 0
        else:
                        # arriba o abajo?
            if f - F < 0:
                g = F-1
                if c -C < 0: # izquierda o derecha?
                    h = C -1
                else:
                    h = C+1
            else: 
                g = F+1
                if c -C < 0: # izquierda o derecha?
                    h = C -1
                else:
                    h = C+1
                
            if self.__Raw[g][h].colorbase != jugador.color and self.__Raw[g][h].colorbase != 'black' and  self.__Raw[g][h].colorbase != '  ': 
                self.__casillas[g][h] =  CasillaNegra(g,h).Representacion      
                self.__Raw[g][h] =  CasillaNegra(g,h) 
                valcor2 = []
                v2 = []
                for elem in Validacion2:
                    valcor2.extend(str(elem.fila))
                    valcor2.extend(str(elem.columna))
                    v2.append([valcor2.pop(0),valcor2.pop(0)])
                tabicor2 = []    
                tabicor2.extend(str(self.__Raw[f][c].fila))
                tabicor2.extend(str(self.__Raw[f][c].columna))
                q = v2.index(tabicor2)
                self.__casillas[f][c] = Validacion2[q].Representacion
                self.__casillas[F][C] = CasillaNegra(F,C).Representacion
                self.__Raw[f][c] = Validacion2[q]
                self.__Raw[F][C] = CasillaNegra(F,C)
                if self.__Raw[f][c].colorbase == 'blanca' and self.__Raw[f][c].fila == 0:
                    self.__casillas[f][c] = ReinaBlanca[f][c].Representacion
                    self.__Raw[f][c] = ReinaBlanca(f,c)
            
                elif self.__Raw[f][c].colorbase == 'negra' and self.__Raw[f][c].fila == 7:
                    self.__casillas[f][c] = ReinaNegra(f,c).Representacion
                    self.__Raw[f][c] = ReinaNegra(f,c)
                
                    

                puntaje = 1 
            else:
                raise Exception('Jugada no válida')
     return puntaje            
                    
    def Traducir(self):
        for crow in self.__casillas: #por cada fila en tablero
           i = 0
           print()
           while i<6:
      #nuevotablero = []
               for relem in crow: # por cada elemento en la fila       
       
                   j = 0
       
                   while j<6:
         
          #nuevotablero.append(relem[i][j])
                       print(relem[i][j], end=" ")
                       j +=1
               i +=1
        
        # for i in range(8):
        #     for j in range(8):
                
        #         return self.__casillas[i][j]
       
    
    def __repr__(self):
        
        return self.__casillas + self.__Raw
        
# # for row in range(len(tablero)):
# #     for column in range(len(tablero[row])):
# #      print(tablero[row][column])
#         for crow in self.__casillas: #por cada fila en tablero
#             i = 0
#             print()
#             while i<5:
#       #nuevotablero = []
#                 for relem in crow: # por cada elemento en la fila       
       
#                     j = 0
       
#                     while j<5:
         
#           #nuevotablero.append(relem[i][j])
#                         print(relem.Representacion, end=" ")
#                         j +=1
#                 i +=1
        