# HPGL-to-GCODE
A simple HPGL to GCODE converter. It converts HP Plotter Instructions to GCODE used by CNC Machines (e.g. 3D printers)

Inkscape is the only program i found to create plotting paths, being able to take care of the offset blades used in these drag knifes.
Unfortunately, Inkscape cannot save the output file as GCODE instructions. To solve this problem, i created this converter.

The software only handles the "Pen Up" and "Pen Down" commands present in the hpgl file.
Tool number, pressure or feedrate will not be translated to gcode.
You can set up feedrates, cutting depth and some more parameters in different profiles.
