
class Jugador():

    # SECCIÓN DE CONSTRUCTORES
    
    def __init__(self, nombre, color):
        self.__nombre = nombre
        self.__color = color 
        self.__puntaje = 12
        


    @property
    def nombre(self):
        return self.__nombre

    @property
    def color(self):
        return self.__color
    
    @property
    def puntaje(self):
        return(self.__puntaje)
    def Puntuacion(self,punt):
        self.__puntaje = self.__puntaje + punt
        return self.__puntaje

    def Ganador(self,puntuacion):
        if puntuacion  == 24:
            ganador = 0
        else:
            ganador = 1
        return ganador
    def __str__(self):
        return '(' + self.__nombre +self.__color +self.__puntaje +')'