;/// <summary>
;/// Miksowanie obrazów
;/// Alorytm pozwala na po³¹czenie dwóch obrazów o takiej samej rozdzielczoœci i wybranie wspó³czynnika mieszania
;/// 2022/2023 Sem.5 Jakub Hoœ gr.2
;/// v1.0
;/// </summary>

.code 
mixAsm proc
;clearing register which will be used in procedure
xor r10, r10
xor r11, r11
xor rbx, rbx
;moving first procedure argument to r10(pixelA)
mov r10, rcx
;moving second procedure argument to r11(pixelB)
mov r11, rdx
;moving third procedure argument to rbx(u)
mov rbx, r8

mov rax, 256
sub rax, rbx
;rax = |u|1-i|u|1-u|
mov ah, bl			

;moving rax to xmm5
movq xmm5, rax

PMOVZXBW xmm5, xmm5
punpckldq xmm5, xmm5
punpckldq xmm5, xmm5


;moving pixels to xmm registers
movq xmm0, r10	;xmm0 = |x|x|x|x|x|x|x|x|x|x|x|x|x|R1|G1|B1|
movq xmm1, r11	;xmm1 = |x|x|x|x|x|x|x|x|x|x|x|x|x|R2|G2|B2|


;Zero extend packed 8bit integers int the low 8bytes of xmm0 to packed 16bit
PMOVZXBW xmm0, xmm0		;xmm0 = |00 00|00 R1|00 G1|00 B1|
;Zero extend packed 8bit integers int the low 8bytes of xmm1 to packed 16bit
PMOVZXBW xmm1, xmm1		;xmm1 = |00 B3|00 R2|00 G2|00 B2|

movups xmm2, xmm0
movups xmm3, xmm1

;Interleave low-order words from xmm1 into xmm0
punpcklwd xmm0, xmm1	;xmm0 = |G2 |00 G1|00 B2|00 B1|
;Interleave low-order words from xmm3 into xmm2
punpckhwd xmm2, xmm3	;xmm2 = |00 00|00 00|00 R2|00 R1|


;Multiplying and adding packed integers
pmaddwd xmm0, xmm5	;xmm0 = |u*G2 + (1-u)*G1|u*B2 + (1-u)*B1|
pmaddwd xmm2, xmm5	;xmm2 = |00|u*R2 + (1-u)*R1|

;xmm0 = xmm0 >> 8
psrld     xmm0, 8
;xmm2 = xmm0 >> 8
psrld     xmm2, 8

;Converts 2 packed signed doubleword integers
packssdw  xmm0, xmm2
;Converts 2 packed signed doubleword integers
packuswb xmm0, xmm6

;Result left in eax
movd rax, xmm0

ret
mixAsm endp
end