class Ficha():

    # SECCIÓN DE CONSTRUCTORES
     
    def __init__(self, fila, columna, color = ' ',colorbase = ' '):
        self.__fila = fila
        self.__columna = columna
        self.__color = color
        self.__colorbase = colorbase
        self.__posiblesmov =[]
        self.__posiblescomer = []
    
        # self.__posiblesMov = []
        # self.__posiblesComer = []
        n = 7 #filas
        m = 7 #columnas
        if color == ' ':
            
     
          casilla = [["  "] * m for i in range(n)]
          i = 1
          j = 0
          for i in range (1,6):
              if j == 0:
                  casilla[i][j] = '|'
                  j = 5
                                                                                                           
              casilla[i][j] = '|'
              j = 0
          i = 0  
          casilla[0][0] =' '   #se redefine el primer espacio de la primera fila
          casilla[0][5] = ' '
          while (i == 0):
              for j in range (1,5):
                  casilla[i][j] = '__'
      
              i=5
          while (i == 5):
               for j in range (1,5):
                casilla[i][j] = '__'
          
               i = 1
          casilla[3][2] = ' '+ str(self.__fila)
          casilla[3][3] = str(self.__columna) + ' '
        elif color =='black':          
          casilla = [["  "] * m for i in range(n)]
          i = 1
          j = 0
          for i in range (1,6):
              if j == 0:
                  casilla[i][j] = '|'
                  j = 5
                                                                                                           
              casilla[i][j] = '|'
              j = 0
          i = 0  
          casilla[0][0] =' '   #se redefine el primer espacio de la primera fila
          casilla[0][5] = ' '
          for i in range(6):
              for j in range (1,5):
                  casilla[i][j] = '__'
          casilla[3][2] =' '  + str(self.__fila)
          casilla[3][3] = str(self.__columna) + ' '
        elif color == 'blanca':   
            casilla = [["  "] * m for i in range(n)]
            i = 1
            j = 0
            for i in range (1,6):
                if j == 0:
                   casilla[i][j] = '|'
                   j = 5
                                                                                                           
                casilla[i][j] = '|'
                j = 0
            i = 0  
            casilla[0][0] =' '   #se redefine el primer espacio de la primera fila
            casilla[0][5] = ' '
            for i in range(6):
                for j in range (1,5):
                    casilla[i][j] = '__'
            casilla[3][2] ='|'  + str(self.__fila)
            casilla[3][3] = str(self.__columna) + '|'
            casilla[2][2] ='/ '  
            casilla[2][3] = ' '+ chr(92)
            casilla[4][2] ='\_'
            casilla[4][3] = '_/'
            casilla[1][2] =' _'  
            casilla[1][3] = '_ '
        elif color == 'negra':   
            casilla = [["  "] * m for i in range(n)]
            i = 1
            j = 0
            for i in range (1,6):
                if j == 0:
                   casilla[i][j] = '|'
                   j = 5
                                                                                                           
                casilla[i][j] = '|'
                j = 0
            i = 0  
            casilla[0][0] =' '   #se redefine el primer espacio de la primera fila
            casilla[0][5] = ' '
            for i in range(6):
                for j in range (1,5):
                    casilla[i][j] = '__'
            casilla[3][2] ='|'  + str(self.__fila)
            casilla[3][3] = str(self.__columna) + '|'
            casilla[2][2] ='/]'  
            casilla[2][3] ='[' + chr(92)
            casilla[4][2] ='\]'
            casilla[4][3] = '[/'
            casilla[1][2] =' _'  
            casilla[1][3] = '_ '
        elif color == 'breina':   
            casilla = [["  "] * m for i in range(n)]
            i = 1
            j = 0
            for i in range (1,6):
                if j == 0:
                   casilla[i][j] = '|'
                   j = 5
                                                                                                           
                casilla[i][j] = '|'
                j = 0
            i = 0  
            casilla[0][0] =' '   #se redefine el primer espacio de la primera fila
            casilla[0][5] = ' '
            for i in range(6):
                for j in range (1,5):
                    casilla[i][j] = '__'
            casilla[3][2] ='|'  + str(self.__fila)
            casilla[3][3] = str(self.__columna) + '|'
            casilla[2][2] ='/M'  
            casilla[2][3] = 'M'+ chr(92)
            casilla[4][2] ='\_'
            casilla[4][3] = '_/'
            casilla[1][2] =' _'  
            casilla[1][3] = '_ '
        elif color == 'nreina':   
            casilla = [["  "] * m for i in range(n)]
            i = 1
            j = 0
            for i in range (1,6):
                if j == 0:
                   casilla[i][j] = '|'
                   j = 5
                                                                                                           
                casilla[i][j] = '|'
                j = 0
            i = 0  
            casilla[0][0] =' '   #se redefine el primer espacio de la primera fila
            casilla[0][5] = ' '
            for i in range(6):
                for j in range (1,5):
                    casilla[i][j] = '__'
            casilla[3][2] ='|'  + str(self.__fila)
            casilla[3][3] = str(self.__columna) + '|'
            casilla[2][2] ='/M'  
            casilla[2][3] ='M' + chr(92)
            casilla[4][2] ='\]'
            casilla[4][3] = '[/'
            casilla[1][2] =' _'  
            casilla[1][3] = '_ '
        self.__representacion = casilla
        
    #def __init__(self, fila, columna):
       # self.__fila = fila
        #self.__color = "" 
        #self.__columna = columna   
        
        
    @property
    def fila(self):
         return self.__fila
    
    @property
    def columna(self):
         return self.__columna
    @property
    def colorbase(self):
        return self.__colorbase
    @property
    def color(self):
        return self.__color
    @property
    def Representacion(self):
        return self.__representacion
    @property
    def posiblesmov(self):
         return self.__posiblesmov
    
    @property
    def posiblescomer(self):
         return self.__posiblescomer  
     
    def __str__(self):
         return "(" + self.__color + self.__fila + self.__columna + self.__representacion 
         + self.__posiblesmov +  self.__posiblescomer  + self.__colorbase + ")"
   
 
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    # def Representacion(self,color):
    #     if color == ' ':
    #         n = 5 #filas
    #         m = 5 #columnas
    #         casilla = [["  "] * m for i in range(n)]
    #         i = 1
    #         j = 0
    #         for i in range (1,5):
    #             if j == 0:
    #                 casilla[i][j] = '|'
    #                 j = 4
                                                                                                           
    #             casilla[i][j] = '|'
    #             j = 0
    #         i = 0  
    #         casilla[0][0] =' '   #se redefine el primer espacio de la primera fila
    #         casilla[0][4] = ' '
    #         while (i == 0):
    #             for j in range (1,4):
    #                 casilla[i][j] = '__'
      
    #             i=4
    #         while (i == 4):
    #             for j in range (1,4):
    #                 casilla[i][j] = '__'
      
    #             i = 1
    #     return casilla    
    
    
    
    
    # def __str__ (self):
    #     return "(" + self.__color + self.__fila + self.columna + ")"
    # def __repr__(self):
    #      return "(" + self.__color + self.__fila + self.columna + ")"