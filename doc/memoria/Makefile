all: memoria.pdf

.PHONY: memoria.pdf

memoria.pdf:
	hal memoria.hal > memoria.tex
	pdflatex -shell-escape memoria.tex
	pdflatex -shell-escape memoria.tex
