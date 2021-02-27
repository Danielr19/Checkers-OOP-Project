# -*- coding: utf-8 -*-
"""
Created on Sun Jul 12 09:03:46 2020

@author: Hijos
"""


from Ficha import Ficha

class ReinaNegra(Ficha):
    def __init__(self,fila,columna):
        super().__init__(fila,columna,"nreina",'negra')
        
        self.__posiblesMov = []
        self.__posiblesComer = []
        self.__fila = fila
        self.__columna = columna
    @property
    def PosiblesMov(self):
        
        return self.__posiblesMov
    @property    
    def PosiblesComer(self):
        
        return self.__posiblesComer
    def PosiblesMov(self):
        
          
            if self.__fila != 0 and self.__columna == 0:
            
                self.__posiblesMov.append(ReinaNegra(self.__fila - 1, self.__columna + 1))
                
            elif self.__fila != 0 and self.__columna == 7:
            
                self.__posiblesMov.append(ReinaNegra(self.__fila - 1, self.__columna - 1))
              
            
            elif self.__fila != 0:
            
                self.__posiblesMov.append(ReinaNegra(self.__fila - 1, self.__columna + 1))
                self.__posiblesMov.append(ReinaNegra(self.__fila - 1, self.__columna - 1))
         
            if self.__fila != 7 and self.__columna == 0:
            
                self.__posiblesMov.append(ReinaNegra(self.__fila + 1, self.__columna + 1))
              
            
            elif self.__fila != 7 and self.__columna == 7:
            
                self.__posiblesMov.append(ReinaNegra(self.__fila + 1, self.__columna - 1))
                
            
            elif self.__fila != 7:
            
                self.__posiblesMov.append(ReinaNegra(self.__fila + 1, self.__columna + 1))
                self.__posiblesMov.append(ReinaNegra(self.__fila + 1, self.__columna - 1))
            

            return self.__posiblesMov
        
       
    def PosiblesComer(self):
        
            
            if self.__fila > 1 and self.__columna < 2:
            
                self.__posiblesComer.append(ReinaNegra(self.__fila - 2, self.__columna + 2))
            
            elif self.__fila > 1 and self.__columna > 5:
            
                self.__posiblesComer.append(ReinaNegra(self.__fila - 2, self.__columna - 2))
            
            elif self.__fila > 1:
            
                self.__posiblesComer.append(ReinaNegra(self.__fila - 2, self.__columna - 2))
                self.__posiblesComer.append(ReinaNegra(self.__fila - 2, self.__columna + 2))
            
            if self.__fila < 6 and self.__columna < 2:
            
                self.__posiblesComer.append(ReinaNegra(self.__fila + 2, self.__columna + 2))
            
            elif self.__fila < 6 and self.__columna > 5:
            
                self.__posiblesComer.append(ReinaNegra(self.__fila + 2, self.__columna - 2))
            
            elif self.__fila < 6:
            
                self.__posiblesComer.append(ReinaNegra(self.__fila + 2, self.__columna + 2))
                self.__posiblesComer.append(ReinaNegra(self.__fila + 2, self.__columna - 2))
            
            return self.__posiblesComer   
        
        
               
    