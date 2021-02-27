# -*- coding: utf-8 -*-
"""
Created on Sat Jul 11 23:48:01 2020

@author: Hijos
"""


from Tablero import Tablero
from Jugador import Jugador
# from Iniciador_de_Tablero import Iniciador_de_Tablero
def ValidacionP (F,C,jugador):
    if jugador.color == tabi.Raw[F][C].colorbase:
    
        pomov = tabi.Raw[F][C].PosiblesMov()
        return pomov    
    else:
        raise Exception ('Jugada no válida')            
def ValidacionC(F,C,jugador):                
    if jugador.color == tabi.Raw[F][C].colorbase:
        
        pocom = tabi.Raw[F][C].PosiblesComer()            
        return pocom
        
    else:
        raise Exception ('Jugada no válida') 
def Imprimir (casilla):
    
    for row in casilla:
        print(' '.join([str(elem) for elem in row]))
def Analizar (validacionP,validacionC): #se comprueba si el jugador seleccionó una primera casilla válida(negra)
    if len(str(validacionP)) != 0 or len(str(validacionC)) !=0:
        return True
    else:
        return False
def Comparacion(f,c,val1,val2):
    if val1 == 0:
        
        valcor = []
        v = []
        for elem in val2:
            valcor.extend(str(elem.fila))
            valcor.extend(str(elem.columna))
            v.append([valcor.pop(0),valcor.pop(0)])
        tabicor = []    
        tabicor.extend(str(tabi.Raw[f][c].fila))
        tabicor.extend(str(tabi.Raw[f][c].columna))
  
        if v.count(tabicor) !=0:
        
            return True
        else:
            return False
    elif val2 ==0:
        valcor = []
        v = []
        for elem in val1:
            valcor.extend(str(elem.fila))
            valcor.extend(str(elem.columna))
            v.append([valcor.pop(0),valcor.pop(0)])
        tabicor = []    
        tabicor.extend(str(tabi.Raw[f][c].fila))
        tabicor.extend(str(tabi.Raw[f][c].columna))
  
        if v.count(tabicor) !=0:
        
            return True
        else:
            return False        
    else:        
        val1.extend(val2)
        valcor = []
        v = []
        for elem in val1:
            valcor.extend(str(elem.fila))
            valcor.extend(str(elem.columna))
            v.append([valcor.pop(0),valcor.pop(0)])
        tabicor = []    
        tabicor.extend(str(tabi.Raw[f][c].fila))
        tabicor.extend(str(tabi.Raw[f][c].columna))
  
        if v.count(tabicor) !=0:
 
            return True
        else:
            return False
def Inspect (f,c):
     
     if tabi.Raw[f][c].colorbase == 'black':
         
         return True
     else:
         return False
def Sondeo(Val,jugador):
        valcor = []
        v = []
        vlil = []
        Lil = []
        cont = 0
        
        for elem in Val:
            valcor.extend(str(elem.fila))
            valcor.extend(str(elem.columna))
            v.append([valcor.pop(0),valcor.pop(0)])
        for fila in tabi.Raw:
            for casilla in fila:
                                           # if casilla.colorbase != jugador.color and casilla.colorbase != 'black' and  casilla.colorbase != '  '
                if casilla.colorbase == 'black':
                    vlil.extend(str(casilla.fila))
                    vlil.extend(str(casilla.columna))
                    Lil.append([vlil.pop(0),vlil.pop(0)])
        
        if len(Lil) != 0:
            c = True
            while c:
                for par in Lil:
                    if v.count(par) !=0: 
                        cont += 1
                        c = False
                c = False        
            if cont !=0:
                return True
            else:
                return False
        else:
            return False
def SondeoFinal(val,jugador):
        valcor = []
        v = []
        vlil = []
        Lil = []
        cont = 0
        
        for elem in val:
            valcor.extend(str(elem.fila))
            valcor.extend(str(elem.columna))
            v.append([valcor.pop(0),valcor.pop(0)])
        
        for fila in tabi.Raw:
            for casilla in fila:
                if casilla.colorbase != jugador.color and casilla.colorbase != 'black' and  casilla.colorbase != '  ':
            
                    vlil.extend(str(casilla.fila))
                    vlil.extend(str(casilla.columna))
                    Lil.append([vlil.pop(0),vlil.pop(0)])
        if len(Lil) !=0:
            c = True
            while c:
                for par in Lil:
                    if v.count(par) !=0: 
                        cont += 1
                        c = False
                c = False        
            if cont !=0:
                return True
            else:
                return False
        else:
            return False
tabi = Tablero()
# tabi.Inicio()

print('Bienvenido a Damas Inglesas')
print('''Para apreciar adecuadamente el tablero expanda la ventana de su 
consola hasta que la flecha apenas
se vea en toda su extensión''')
print()
print('''          < 
        <
      <  =======================================================================================================================
        < 
          <''')
print('¿Desea iniciar un nuevo juego?')
print('Presione ENTER para inicar')
input()

tabi.Inicio()
# Imprimir(tabi.Casillas[0][0])
# Imprimir(tabi.Casillas[0][1])
tabi.ColocarFichas()
nombre1 = input('Jugador uno (blancas), escriba su nombre ')
jugador1 = Jugador(nombre1,'blanca')
nombre2 = input('Jugador dos (negras), escriba su nombre ')
jugador2 = Jugador(nombre2,'negra')
turno = 'blancas'
juego = True 

tabi.Traducir() #Se imprime una representación en string de la propiedad Referencia de cada objeto Ficha
jugador = jugador1
 
while juego:
        print()
    
       
    
        print('Es el turno de ', jugador.nombre)
        print()
        posibilidad = input('¿Consideras que puedes moverte?(si/no)')
        if posibilidad == 'si':
        
            print ()
            
            print('Indica las coordenadas de la ficha que deseas mover')
       
        
            F = input('Escribe el número de la fila')
        
            C = input('Escribe el número de la columna')
            Validacion1 = ValidacionP(int(F),int(C),jugador)
            Validacion2 = ValidacionC(int(F),int(C),jugador)#analizan los posibles movimientos ideales de la ficha(no hay obstáculos)
            
            analizar = Analizar(Validacion1, Validacion2)#se comprueba si el jugador seleccionó una primera casilla válida(negra)
            if analizar == True:
                print()
                print('Indique las coordenadas de la casilla a donde desea moverse')
                f = input('Escribe el número de la fila')
        
                c = input('Escribe el número de la columna')
                
                
               
                comp = Comparacion(int(f),int(c),Validacion1,Validacion2) #Comprueba que se haya escogido una de las movidas válidas
            
                if comp == True:
                    In = Inspect(int(f),int(c)) # comprueba que se haya seleccionado una casilla desocupada
                    if In == True:
                        del Validacion1[:]
                        Validacion1 = ValidacionP(int(F),int(C),jugador)
                        puntos = tabi.Refresh(int(F),int(C),int(f),int(c),Validacion1,Validacion2,jugador) #Éste método actualiza el movimiento validado del usuario
                        tabi.Traducir()
                        puntuacion = jugador.Puntuacion(puntos) 
                        cadena = True
                        while cadena:
                            vj = Comparacion(int(f),int(c),Validacion1,0) #se analiza si la jugada anterior fue comer una ficha
                            if vj == False:
                                val1 = ValidacionP(int(f),int(c),jugador) #para poder averiguar si hay fichas del color contrario susceptibles de ser comidas
                                val2 = ValidacionC(int(f),int(c),jugador)
                                sond = Sondeo(val2,jugador) # analiza si existen casillas desocupadas después de comer
                                sond2 = SondeoFinal(val1,jugador)#analiza si existen fichas contrarias susceptibles de ser comidas
                                if sond == True and sond2 == True:
                                    encadenar = input('¿Desea encadenar?(si/no)')
                                    if encadenar == 'si':
                                        print('Indique las coordenadas de la casilla a donde desea moverse')
                                        r = input('Escribe el número de la fila')
        
                                        s = input('Escribe el número de la columna')    
                                        compi = Comparacion(int(r),int(s),0,val2)
                                        if compi == True:
                                            In = Inspect(int(r),int(s))
                                            if In == True:
                                                puntos = tabi.Refresh(int(f),int(c),int(r),int(s),0,val2,jugador) #Éste método actualiza el movimiento validado del usuario
                                                tabi.Traducir()
                                                puntuacion = jugador.Puntuacion(puntos)
                                                f = r
                                                c = s
                                            else:
                                                cadena = False
                                        else:
                                            cadena = False
                                    else:
                                        cadena = False
                            
                                else:
                                    cadena = False
                            else:
                              cadena = False
                        ganador = jugador.Ganador(puntuacion)#Se analizan las condiciones para la victoria
                        if ganador == 0:
                            print('¡¡Felicidades jugador ', jugador.nombre, ', haz ganado la partida' )
                            juego = False               
                        else:
                            if jugador == jugador1:
                                jugador = jugador2
                            else:
                                jugador = jugador1
                    else:
                        raise Exception('Parece que la casilla a la que desea mover está ocupada por otra ficha')
                else:
                    raise Exception('Jugada no válida')
            else:
                raise Exception('Jugada no válida')
        else:
            if jugador == jugador1:
                jugador = jugador2
            else:
                jugador = jugador1 
            
            print('¡¡Felicidades jugador ', jugador.nombre, ', haz ganado la partida' )
            juego = False
                    
                    
# Diseños
#  __ __ __ __
# |__  _ _  __|
# |__ /   \ __|
# |__ |0 6| __|
# |__ \_ _/ __|
# |__ __ __ __|

#  __ __ __ __
# |__  _ _  __|
# |__ /] [\ __|
# |__ |0 6| __|
# |__ \] [/ __|
# |__ __ __ __|

#  __ __ __ __
# |__ __ __ __|
# |__ __ __ __|
# |__  0 6  __|
# |__ __ __ __|
# |__ __ __ __|

#  __ __ __ __
# |           |
# |           |
# |           |
# |           |
# |__ __ __ __|

#  __ __ __ __
# |    _ _    |
# |   /   \   |
# |   |   |   |
# |   \_ _/   |
# |__ __ __ __|

#  __ __ __ __
# |    _ _    |
# |   /- -\   |
# |   || ||   |
# |   \_ _/   |
# |__ __ __ __|
#  __ __ __ __
# |__  _ _  __|
# |__ /M M\ __|
# |__ |0 6| __|
# |__ \_ _/ __|
# |__ __ __ __|

#  __ __ __ __
# |__  _ _  __|
# |__ /M M\ __|
# |__ |0 6| __|
# |__ \] [/ __|
# |__ __ __ __|



