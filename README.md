# FlightGear Controller
We built a GUI interface (WPF application) which will allow us to control the plane in [FlightGear](http://home.flightgear.org/) simulator
### Dependencies:
Add generic_small.xml to [$FG_ROOT](http://wiki.flightgear.org/$FG_ROOT)/Protocol/ directory.
Make sure to run FlightGear with the following settings:

`--generic=socket,out,10,SERVER_IP,INFO_PORT,tcp,generic_small`

`--telnet=socket,in,10,SERVER_IP,COMMAND_PORT,tcp`

### Operating Instructions
1 First run the app(GUI), make sure the settings are correct, and then click connect.
2 Start FlightGear simulator with the above settings.
3 Controll the plane via manual or automatic controller.
* Manual - controll rudder, throttle, aielron and elevator  values
* Automatic - press OK to send set of [commands](http://wiki.flightgear.org/Telnet_usage#set) to the simulator, there is two seconds delay between commands.
