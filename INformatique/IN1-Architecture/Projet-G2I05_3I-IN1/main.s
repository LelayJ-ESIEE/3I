; J. LELAY, B. SECHEHAYE, G2I05_3I-IN1 - ESIEE Paris -
; 11/2020 - Evalbot (Cortex M3 de Texas Instrument)
; Main loop

GPIO_6			EQU		0x40
PORTD_BASE		EQU		0x40007000

		AREA    |.text|, CODE, READONLY
		ENTRY
		EXPORT	__main

		IMPORT	INIT
		IMPORT	MOTEUR_PIVOTE_DROITE
		IMPORT	MOTEUR_PIVOTE_GAUCHE
		IMPORT	MOTEUR_DEMI_TOUR
		IMPORT	MOTEUR_AVANCE
		IMPORT	CHOIX_DIRECTION
		IMPORT	SOLVE_MAZE
		
__main	  		   

		; initialization
		; Configure GPIO
		BL	INIT
		
		; Beginning control
		; Read SW1 state
nogo	LDR R12,= (PORTD_BASE + (GPIO_6<<2))
		LDR	R11, [R12]
		; If SW1 is not active(!=40), don't start. Else, keep going
		CMP R11,#GPIO_6
		BEQ	nogo

		BL	SOLVE_MAZE
		
loop
		BL CHOIX_DIRECTION
		CMP	R3, R7	; If already well oriented
		BEQ	avance
		CMP	R3,	#0	; if facing north
		BEQ	cmpn
		MOV R11, R3
		SUB R11, R11, #1
		CMP	R11, R7	; if not north and has to turn left
		BEQ	gauche
		CMP	R3, #3	; if facing east
		B	cmpe
cmpd	MOV R11, R3
		ADD R11, R11, #1	; if not east and has to turn right
		CMP	R11, R7
		BEQ	droite
		B	demi
cmpn	CMP R7, #3	; if north and has to turn left
		BEQ gauche
		B	cmpd
cmpe	CMP	R7, #0	; if not east and has to turn right
		BEQ	droite
		B	demi
		
droite	BL	MOTEUR_PIVOTE_DROITE
		b avance
		
gauche	BL	MOTEUR_PIVOTE_GAUCHE
		b avance
		
demi	BL	MOTEUR_DEMI_TOUR
		b avance
		
avance	BL	MOTEUR_AVANCE
		MOV	R3, R7	; actualize orientation
		ADD	R1, R5	; actualize x
		ADD	R2, R6	; actualize y
		CMP	R0, #0
		BEQ	fin

		b	loop
		b	fin
fin
		BL	MOTEUR_AVANCE 	; exit maze if arrived to its entry
		NOP
        END