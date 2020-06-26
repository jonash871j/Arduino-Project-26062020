#include "sh_communication.h"
#include "sh_controller.h"

controller_pinout_t controller_pinout;
controller_t controller;

void setup()
{
	Serial.begin(11200);
	sh_controller_pinout(&controller_pinout, A0, A1, 2, 3, 4, 5, 6, 7, 8);
}

void loop()
{
	sh_controller_update(&controller_pinout, &controller);
	sh_communication_send(&controller, "controller", sizeof(controller_t), UDP);
}
