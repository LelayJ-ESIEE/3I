; J. LELAY, B. SECHEHAYE, G2I05_3I-IN1 - ESIEE Paris -
; 11/2020 - Evalbot (Cortex M3 de Texas Instrument)
; Fonctions

GPIO_3			EQU		0x08
GPIO_6			EQU		0x40
	
DUREE90			EQU		0x01555554				; Time for a quarter turn

SYSCTL_RCGC2	EQU		0x400FE108				; SYSCTL_RCGC2: offset 0x108 (p291 datasheet de lm3s9b92.pdf)

PORTD_BASE		EQU		0x40007000				; Base Address 
GPIODATA_D		EQU		PORTD_BASE				; The GPIODATA register is the data register
GPIOPUR_D		EQU		PORTD_BASE+0x00000510	; The GPIOPUR  register (Pull Up Resistor). 
GPIODEN_D		EQU		PORTD_BASE+0x0000051C	; The GPIODEN  register (Digital ENable). To use a switch, the corresponding bit must be set.

		AREA    |.text|, CODE, READONLY
		ENTRY
		
		EXPORT	INIT
		EXPORT	CHOIX_DIRECTION
		EXPORT	SOLVE_MAZE
	
		EXPORT	MOTEUR_PIVOTE_DROITE			
		EXPORT	MOTEUR_PIVOTE_GAUCHE
		EXPORT	MOTEUR_DEMI_TOUR
		EXPORT	MOTEUR_AVANCE
		
		;; The IMPORT command specifies that a symbol is defined in a shared object at runtime.
		
		IMPORT	MOTEUR_INIT
		
		IMPORT	MOTEUR_DROIT_ON
		IMPORT	MOTEUR_DROIT_OFF
		IMPORT	MOTEUR_DROIT_AVANT
		IMPORT	MOTEUR_DROIT_ARRIERE
		IMPORT	MOTEUR_DROIT_INVERSE
		
		IMPORT	MOTEUR_GAUCHE_ON
		IMPORT	MOTEUR_GAUCHE_OFF
		IMPORT	MOTEUR_GAUCHE_AVANT
		IMPORT	MOTEUR_GAUCHE_ARRIERE
		IMPORT	MOTEUR_GAUCHE_INVERSE

SW_INIT	; Initialize SW1
		PUSH {LR}
		LDR R12, = GPIODEN_D
		STR R11, [R12] 		
		ORR R11, R11, #GPIO_6
		STR R11, [R12]
		
		LDR R12, = GPIOPUR_D
		ldr R11, [R12] 		
		ORR R11, R11, #GPIO_6
		STR R11, [R12]
		POP {LR}
		BX LR

INIT	; Initialize EvalBot
		; Enable clock port D (SW) GPIO
		PUSH {LR}
		ldr R12, = SYSCTL_RCGC2
		ldr R11, [R12] 		
		ORR R11, #GPIO_3
		str R11, [R12]
		
		nop
		nop
		nop
		
		; Initialize SW1
		BL SW_INIT
		; Initialize motors
		BL MOTEUR_INIT
		; Initialize X, Y and rotation registers
		LDR		R12, = X
		LDRB	R1, [R12]
		LDR		R12, = Y
		LDRB	R2, [R12]
		MOV		R3, #0
		
		POP {LR}
		BX	LR
			
MOTEUR_PIVOTE_DROITE
		PUSH	{LR}
		BL		MOTEUR_DROIT_ARRIERE
		BL		MOTEUR_GAUCHE_AVANT
		BL		MOTEUR_DROIT_ON
		BL		MOTEUR_GAUCHE_ON
		ldr		R11, = DUREE90
wait_d	SUBS	R11, #1
		BNE		wait_d
		BL		MOTEUR_DROIT_OFF
		BL		MOTEUR_GAUCHE_OFF
		POP 	{LR}
		BX		LR
		
MOTEUR_PIVOTE_GAUCHE
		PUSH {LR}
		BL		MOTEUR_DROIT_AVANT
		BL		MOTEUR_GAUCHE_ARRIERE
		BL		MOTEUR_DROIT_ON
		BL		MOTEUR_GAUCHE_ON
		ldr		R11, = DUREE90
wait_g	SUBS	R11, #1
		BNE		wait_g
		BL		MOTEUR_DROIT_OFF
		BL		MOTEUR_GAUCHE_OFF
		POP {LR}
		BX	LR
		
MOTEUR_DEMI_TOUR
		PUSH {LR}
		BL	MOTEUR_PIVOTE_DROITE
		BL	MOTEUR_PIVOTE_DROITE
		POP {LR}
		BX	LR

MOTEUR_AVANCE
		PUSH {LR}
		BL		MOTEUR_INIT
		BL		MOTEUR_DROIT_AVANT
		BL		MOTEUR_GAUCHE_AVANT
		BL		MOTEUR_DROIT_ON
		BL		MOTEUR_GAUCHE_ON
		MOV		r10, #2
wait_2	LDR		R11, = DUREE90
wait_1	SUBS	R11, #1
		BNE		wait_1
		SUBS	R10, #1
		BNE		wait_2
		BL		MOTEUR_DROIT_OFF
		BL		MOTEUR_GAUCHE_OFF
		POP {LR}
		BX	LR

CHOIX_DIRECTION
		PUSH {LR}
		LDR		R12, = LARGEUR
		LDRB	R10, [R12]
		MUL		R11, R10, R2
		LDR		R12, = CASES
		ADD		R12, R11
		ADD		R12, R1
		LDRB	R0,	[R12]
		SUB		R12, #1
		LDR		R4, [R12]
		ADD		R12, #1
		CMP		R0, R4
		BLS		nright	; If not right
		MOV		R5, #0xFFFFFFFF	; else set values fir right and return
		MOV		R6, #0x00000000
		MOV		R7, #3
		b		stop
nright	ADD		R12, #1
		LDR		R4, [R12]
		SUB		R12, #1
		CMP		R0, R4
		BLS		nleft	; If not left
		MOV		R5, #0x00000001	; else set values for left and return
		MOV		R6, #0x00000000
		MOV		R7, #1
		b		stop
nleft	SUB		R12, R10
		LDR		R4, [R12]
		ADD		R12, R10
		CMP		R0, R4
		BLS		nup	; If not up
		MOV		R5, #0x00000000	; else set values and return
		MOV		R6, #0xFFFFFFFF
		MOV		R7, #0
		b		stop
nup		ADD		R12, R10
		LDR		R4, [R12]
		SUB		R12, R10	; So down
		MOV		R5, #0x00000000	; else set values and return
		MOV		R6, #0x00000001
		MOV		R7, #2
		b		stop
		
stop	POP {LR}
		BX	LR

SOLVE_MAZE
		PUSH {LR}
sloop	MOV 	R0, #0
		MOV 	R11, #1
y		MOV 	R10, #1

x		LDR		R12, = LARGEUR
		LDRB	R9, [R12]
		MUL		R9, R9, R11
		LDR		R12, = CASES
		ADD		R12, R9
		ADD		R12, R10
		LDRB	R8,	[R12]
		CMP		R8, #0xFF
		BEQ		skipb
		SUB		R12, #1
		LDRB	R7,	[R12]
		ADD		R12, #1
		ADD		R7, #1
		CMP		R8, R7
		BLO		skipg
		STRB	R7, [R12]
		MOV		R8, R7
		MOV 	R0, #1

skipg	ADD		R12, #1
		LDRB	R7,	[R12]
		SUB		R12, #1
		ADD		R7, #1

		CMP		R8, R7
		BLO		skipd
		STRB	R7, [R12]
		MOV		R8, R7
		MOV 	R0, #1
		
skipd	LDR		R7, = LARGEUR
		LDRB	R6, [R7]
		SUB		R12, R6
		LDRB	R7,	[R12]
		ADD		R12, R6
		ADD		R7, #1
		CMP		R8, R7
		BLO		skiph
		STRB	R7, [R12]
		MOV		R8, R7
		MOV 	R0, #1
		
skiph	ADD		R12, R6
		LDRB	R7,	[R12]
		SUB		R12, R6
		ADD		R7, #1
		CMP		R8, R7
		BLO		skipb
		STRB	R7, [R12]
		MOV		R8, R7
		MOV 	R0, #1

skipb	LDR		R12, = LARGEUR
		LDRB	R9, [R12]
		ADD		R10, #1
		CMP		R10, R9
		BNE		x
		
		LDR		R12, = HAUTEUR
		LDRB	R9, [R12]
		ADD		R11, #1
		CMP 	R11, R9
		BNE		y
		
		CMP 	R0, #1
		BEQ 	sloop
		
		LDR		R12, = LARGEUR
		LDRB	R11, [R12]
		MUL		R11, R11, R2
		LDR		R12, = CASES
		ADD		R12, R11
		LDRB	R0,	[R12,R1]
		POP {LR}
		BX	LR
		
; Remplace for maze customisation
        AREA    CONSTANTES, DATA, READONLY
X       DCB        1
Y       DCB        2
LARGEUR DCB        10
HAUTEUR DCB        10
        AREA    GRILLE, DATA, READWRITE
CASES   DCB        0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFF, 0xFF, 0xFE, 0xFF, 0xFE, 0xFE, 0xFE, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0xFF, 0xFF, 0xFE, 0xFF, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFF, 0xFF, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF
; End of replacement

		END