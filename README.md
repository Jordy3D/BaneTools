```
 ▄   ▄  
▄██▄▄██▄          ╔╗ ┌─┐┌┐┌┌─┐█  
███▀██▀██         ╠╩╗├─┤│││├┤ █  
▀███████▀         ╚═╝┴ ┴┘└┘└─┘█  
  ▀███████▄▄      ▀▀▀▀▀▀▀▀▀▀▀▀█▀  
   ██████████▄  
 ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█▀   
```
A never-ending collection of potentially useful tools.
This collection is very much a work in progress type thing and is updated as I find new things that may be of use, or I learn new methods of achieving a result.
If you have any suggestions or fixes, feel free to share em however you see fit.

Keep in mind, this package relies on [NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes) right now, mostly for neatness in some of the scripts. The code inside does not rely on it at all however, so if you don't want NaughtyAttributes, feel free to delete the Headers and stuff I am using.

### Usage
`using BT;`

Then, when you want to call a function from ToolFunctions.cs, use:
```cs
BaneTools.FunctionHere();
BaneMath.FunctionHere();
BaneRays.FunctionHere();
```
There's also many extensions you can try, such as:
```cs
transform.CanSee(target);
muzzle.RayForward(range);
myScore.WithinRange(rangeLow, rangeHigh);
```
