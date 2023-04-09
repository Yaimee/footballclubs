Made by Johannes Forsting, Rasmus Ørum, Nicolas Alvi.

This project contains a processor which processeses data from Superliga football league. It takes data from several CSV-files, all consisting of each round played (round-x.csv) in the league, the league setup (setup.csv) and the teams participating (teams.csv). 
The processor takes any number of round-x.csv files and reads each line in the following order: homeclub abbrevation, awayclub abbrevation, and homeclub and awayclub goals (If the order in round-x.csv is not correct, the program will throw an exception).
The setup.csv file contains the positions available for the clubs to promote or relegate to an upper or lower league. The file contains one line (If the setup.csv file is not located in the "Files" directory or if an error occur, the program will throw an exception).
The teams.csv file contains the participating clubs in the league. When read, the clubs will be used to check and compare with the clubs in the round-x.csv files, hence it's important to be precise with the abbrevations in the teams.csv file. The first line contains column definitions: club abbrevation, club full name, and the rest of the lines contain the participating clubs.

Examples of of .csv file setups:

teams.csv:

Abbrevation Name
FCK         Football Club Koebenhavn
BIF	        Broendby Idraetsforening
AGF	        Aarhus gymnastikforening
RFC	        Randers Football Club
...

setup.csv:

name	                UCL positions	UEL positions	UECL positions	Relegation positions	upper positions	Lower positions	Enum
3F Superliga	        0	            0	            0	              0	                    6	              6	              preSplitUp
mesterskabsspillet	  1	            2	            1	              0	                    0	              0	              postSplitUp
Kvalifikationsspillet	0	            0	            0	              2	                    0	              0	              postSplitUp

round-x.csv:

FCN   BIF   0-1
FCM   S     1-2
AaB   FCK   2-3
OB    L     0-1
VB    AGF   0-0
RFC   ACH   3-0

For each processed round, the result will be displayed every 1 second in the console, and written to a result.txt file, in the "./File" directory. After 22 rounds, the results will be split in an upper and lower league, as shown in the console and results file.
