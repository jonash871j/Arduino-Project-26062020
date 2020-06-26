#pragma once
#include "sh_def.h"

enum sh_protocol_t{ TCP, UDP };

// Used to send any structure through serial
void sh_communication_send(
	void* type,
	const char* key,
	uint32_t size,
	sh_protocol_t protocol
);
