#include "sh_communication.h"

#include <Arduino.h>

static String s_read_string()
{
	String readString;

	// Waits until serial is available
	while (Serial.available())
	{
		delay(1);

		// Checks that serial data isn't 0
		if (Serial.available() > 0)
		{
			// Reads byte
			int8_t c = Serial.read();

			// If it's a control character ignore it
			if (isControl(c))
				break;

			// Adds to string
			readString += c;
		}
	}

	return readString;
}

void sh_communication_send(
	void* type,
	const char* key,
	uint32_t size,
	sh_protocol_t protocol)
{
	// Cast void* to byte*
	uint8_t* raw_type = (uint8_t*)type;

	do
	{
		// Creates buffer
		String buffer = key;
		buffer += ":"; //  tSeperateshe key from the byte array

		// Converts each byte to a string and adds it to line
		for (uint32_t i = 0; i < size; i++)
			buffer += String(raw_type[i]) + "-";

		// Write to serial
		Serial.println(buffer);

		// When protocol is UDP, then don't care about lost packets
		if (protocol == UDP)
			break;

		// Checks if packet was recived, if not then send the packet again
	} while (s_read_string() != "#");
}