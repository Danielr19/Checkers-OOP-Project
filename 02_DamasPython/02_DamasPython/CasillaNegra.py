# -*- coding: utf-8 -*-
"""
Created on Sun Jul 12 03:04:45 2020

@author: Hijos
"""


from Ficha import Ficha

class CasillaNegra(Ficha):
    
    def __init__(self, fila, columna):
        super().__init__(fila, columna, 'black', 'black')