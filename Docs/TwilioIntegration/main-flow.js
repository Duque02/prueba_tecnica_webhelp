{
  "description": "A New Flow",
  "states": [
    {
      "name": "Trigger",
      "type": "trigger",
      "transitions": [
        {
          "event": "incomingMessage"
        },
        {
          "next": "say_Welcome",
          "event": "incomingCall"
        },
        {
          "event": "incomingConversationMessage"
        },
        {
          "event": "incomingRequest"
        },
        {
          "event": "incomingParent"
        }
      ],
      "properties": {
        "offset": {
          "x": 60,
          "y": -1600
        }
      }
    },
    {
      "name": "say_Welcome",
      "type": "say-play",
      "transitions": [
        {
          "next": "gather_askCode",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": 260,
          "y": -1380
        },
        "loop": 1,
        "say": "Bienvenido a mi servicio para agendar citas.",
        "language": "es-MX"
      }
    },
    {
      "name": "gather_askCode",
      "type": "gather-input-on-call",
      "transitions": [
        {
          "next": "split_askCode",
          "event": "keypress"
        },
        {
          "event": "speech"
        },
        {
          "next": "Set_RetryNoInput",
          "event": "timeout"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "speech_timeout": "auto",
        "offset": {
          "x": 280,
          "y": -1120
        },
        "loop": 1,
        "finish_on_key": "#",
        "say": "Sí desea agendar una cita presione uno, de lo contrario presione dos.",
        "language": "es-MX",
        "stop_gather": false,
        "gather_language": "es-AR",
        "profanity_filter": "true",
        "timeout": 5
      }
    },
    {
      "name": "split_askCode",
      "type": "split-based-on",
      "transitions": [
        {
          "next": "Set_RetryInitialMenu",
          "event": "noMatch"
        },
        {
          "next": "gather_PatientCode",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "User press 1",
              "arguments": [
                "{{widgets.gather_askCode.Digits}}"
              ],
              "type": "equal_to",
              "value": "1"
            }
          ]
        },
        {
          "next": "say_noNeedAppointment",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "User press 2",
              "arguments": [
                "{{widgets.gather_askCode.Digits}}"
              ],
              "type": "equal_to",
              "value": "2"
            }
          ]
        }
      ],
      "properties": {
        "input": "{{widgets.gather_askCode.Digits}}",
        "offset": {
          "x": 350,
          "y": -870
        }
      }
    },
    {
      "name": "send_to_agent",
      "type": "send-to-flex",
      "transitions": [
        {
          "event": "callComplete"
        },
        {
          "event": "failedToEnqueue"
        },
        {
          "event": "callFailure"
        }
      ],
      "properties": {
        "offset": {
          "x": 480,
          "y": 910
        },
        "workflow": "WWed7929719a02d493a98e77cc58ec8832",
        "channel": "TC83d5487fe0d57d29b9bbb3579843f2ad"
      }
    },
    {
      "name": "gather_PatientCode",
      "type": "gather-input-on-call",
      "transitions": [
        {
          "next": "set_PatientCode",
          "event": "keypress"
        },
        {
          "event": "speech"
        },
        {
          "next": "Set_RetryNoInput1",
          "event": "timeout"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "speech_timeout": "auto",
        "offset": {
          "x": -630,
          "y": -150
        },
        "loop": 1,
        "finish_on_key": "#",
        "say": "Por favor introduce tu código de paciente.",
        "language": "es-MX",
        "stop_gather": true,
        "gather_language": "en",
        "profanity_filter": "true",
        "timeout": 5
      }
    },
    {
      "name": "set_PatientCode",
      "type": "set-variables",
      "transitions": [
        {
          "next": "say_CodeEntered",
          "event": "next"
        }
      ],
      "properties": {
        "variables": [
          {
            "value": "{%- assign number = widgets.gather_PatientCode.Digits | split: \"\" -%}\n{%- for digit in number -%}\n{{ digit }}\n {%- unless forloop.last -%} {%- comment -%} Check if it's the last digit {%- endcomment -%}\n{{ '... ' }} {%- comment -%} Add a space unless it's the last digit {%- endcomment -%}\n {%- endunless -%}\n{%- endfor -%}",
            "key": "patientCode"
          },
          {
            "value": "{{widgets.gather_PatientCode.Digits}}",
            "key": "patientCodeValue"
          }
        ],
        "offset": {
          "x": -630,
          "y": 90
        }
      }
    },
    {
      "name": "say_CodeEntered",
      "type": "say-play",
      "transitions": [
        {
          "next": "say_NumberByNumber",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -630,
          "y": 360
        },
        "loop": 1,
        "say": "Su código es",
        "language": "es-MX"
      }
    },
    {
      "name": "say_NumberByNumber",
      "type": "say-play",
      "transitions": [
        {
          "next": "gather_confirmedNumber",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -630,
          "y": 640
        },
        "loop": 1,
        "say": "{{flow.variables.patientCode}}",
        "language": "es-MX"
      }
    },
    {
      "name": "gather_confirmedNumber",
      "type": "gather-input-on-call",
      "transitions": [
        {
          "next": "split_ConfirmedNumber",
          "event": "keypress"
        },
        {
          "event": "speech"
        },
        {
          "next": "Set_RetryNoInput2",
          "event": "timeout"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "speech_timeout": "auto",
        "offset": {
          "x": -630,
          "y": 880
        },
        "loop": 1,
        "finish_on_key": "#",
        "say": "Si el código es correcto presione uno, de lo contrario presione dos.",
        "language": "es-MX",
        "stop_gather": true,
        "gather_language": "en",
        "profanity_filter": "true",
        "timeout": 5
      }
    },
    {
      "name": "split_ConfirmedNumber",
      "type": "split-based-on",
      "transitions": [
        {
          "next": "Set_RetryNoCondition",
          "event": "noMatch"
        },
        {
          "next": "function_GetCode",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "User press 1",
              "arguments": [
                "{{widgets.gather_confirmedNumber.Digits}}"
              ],
              "type": "equal_to",
              "value": "1"
            }
          ]
        },
        {
          "next": "set_RetryNumber",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "User press 2",
              "arguments": [
                "{{widgets.gather_confirmedNumber.Digits}}"
              ],
              "type": "equal_to",
              "value": "2"
            }
          ]
        }
      ],
      "properties": {
        "input": "{{widgets.gather_confirmedNumber.Digits}}",
        "offset": {
          "x": -1120,
          "y": 1180
        }
      }
    },
    {
      "name": "set_RetryNumber",
      "type": "set-variables",
      "transitions": [
        {
          "next": "split_retryConfirmedNumber",
          "event": "next"
        }
      ],
      "properties": {
        "variables": [
          {
            "value": "{%- if flow.variables.retryNumber -%}{{flow.variables.retryNumber | plus: 1}}\n{%- else -%}\n0\n{%- endif -%}",
            "key": "retryNumber"
          }
        ],
        "offset": {
          "x": -810,
          "y": 1500
        }
      }
    },
    {
      "name": "split_retryConfirmedNumber",
      "type": "split-based-on",
      "transitions": [
        {
          "next": "gather_PatientCode",
          "event": "noMatch"
        },
        {
          "next": "Say_RetryNumber",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "If value greater_than 0",
              "arguments": [
                "{{flow.variables.retryNumber}}"
              ],
              "type": "greater_than",
              "value": "0"
            }
          ]
        }
      ],
      "properties": {
        "input": "{{flow.variables.retryNumber}}",
        "offset": {
          "x": -810,
          "y": 1750
        }
      }
    },
    {
      "name": "send_to_agent2",
      "type": "send-to-flex",
      "transitions": [
        {
          "event": "callComplete"
        },
        {
          "event": "failedToEnqueue"
        },
        {
          "event": "callFailure"
        }
      ],
      "properties": {
        "offset": {
          "x": -280,
          "y": 2270
        },
        "workflow": "WWed7929719a02d493a98e77cc58ec8832",
        "channel": "TC83d5487fe0d57d29b9bbb3579843f2ad"
      }
    },
    {
      "name": "function_GetCode",
      "type": "run-function",
      "transitions": [
        {
          "next": "split_GetCode",
          "event": "success"
        },
        {
          "next": "split_GetCode",
          "event": "fail"
        }
      ],
      "properties": {
        "service_sid": "ZSa16f5805f9dcedc9f47285e8a6626c94",
        "environment_sid": "ZE1fcc5d05fb47812e62b12d457cd8f76b",
        "offset": {
          "x": -1230,
          "y": 1600
        },
        "function_sid": "ZHcee872f59266c464d02d0c9b2b5f1846",
        "parameters": [
          {
            "value": "{{flow.variables.patientCodeValue}}",
            "key": "patientCode"
          }
        ],
        "url": "https://validatepatient-4868.twil.io/get-patient-v1"
      }
    },
    {
      "name": "split_GetCode",
      "type": "split-based-on",
      "transitions": [
        {
          "next": "Set_RetryNoCondition1",
          "event": "noMatch"
        },
        {
          "next": "say_WelcomeUser",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "If value equal_to true",
              "arguments": [
                "{{widgets.function_GetCode.parsed.exists}}"
              ],
              "type": "equal_to",
              "value": "true"
            }
          ]
        },
        {
          "next": "say_NotRegistered",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "If value equal_to false",
              "arguments": [
                "{{widgets.function_GetCode.parsed.exists}}"
              ],
              "type": "equal_to",
              "value": "false"
            }
          ]
        }
      ],
      "properties": {
        "input": "{{widgets.function_GetCode.parsed.exists}}",
        "offset": {
          "x": -2220,
          "y": 1870
        }
      }
    },
    {
      "name": "say_WelcomeUser",
      "type": "say-play",
      "transitions": [
        {
          "next": "function_GetAppointments",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -2490,
          "y": 2530
        },
        "loop": 1,
        "say": "bienvenido {{widgets.function_GetCode.parsed.name}} siga las siguientes instrucciones para agendar una cita.",
        "language": "es-MX"
      }
    },
    {
      "name": "say_NotRegistered",
      "type": "say-play",
      "transitions": [
        {
          "next": "send_to_agent3",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -2030,
          "y": 2610
        },
        "loop": 1,
        "say": "El código que ingreso no está asociado a ningún paciente, por lo tanto te enviaremos con un asesor.",
        "language": "es-MX"
      }
    },
    {
      "name": "send_to_agent3",
      "type": "send-to-flex",
      "transitions": [
        {
          "event": "callComplete"
        },
        {
          "event": "failedToEnqueue"
        },
        {
          "event": "callFailure"
        }
      ],
      "properties": {
        "offset": {
          "x": -1880,
          "y": 2990
        },
        "workflow": "WWed7929719a02d493a98e77cc58ec8832",
        "channel": "TC83d5487fe0d57d29b9bbb3579843f2ad"
      }
    },
    {
      "name": "function_GetAppointments",
      "type": "run-function",
      "transitions": [
        {
          "next": "gather_GetAppointments",
          "event": "success"
        },
        {
          "event": "fail"
        }
      ],
      "properties": {
        "service_sid": "ZSa16f5805f9dcedc9f47285e8a6626c94",
        "environment_sid": "ZE1fcc5d05fb47812e62b12d457cd8f76b",
        "offset": {
          "x": -2660,
          "y": 2840
        },
        "function_sid": "ZH3385cfc76683f010d6c5a11476f99b7c",
        "url": "https://validatepatient-4868.twil.io/get-appointment"
      }
    },
    {
      "name": "gather_GetAppointments",
      "type": "gather-input-on-call",
      "transitions": [
        {
          "next": "set_GetAppointmentId",
          "event": "keypress"
        },
        {
          "event": "speech"
        },
        {
          "next": "say_NotAppointment",
          "event": "timeout"
        }
      ],
      "properties": {
        "speech_timeout": "auto",
        "offset": {
          "x": -2820,
          "y": 3090
        },
        "loop": 1,
        "finish_on_key": "#",
        "say": "{{widgets.function_GetAppointments.parsed.voiceMessage}}",
        "language": "es-MX",
        "stop_gather": true,
        "gather_language": "en",
        "profanity_filter": "true",
        "timeout": 5
      }
    },
    {
      "name": "set_GetAppointmentId",
      "type": "set-variables",
      "transitions": [
        {
          "next": "function_AppointmentSchedule",
          "event": "next"
        }
      ],
      "properties": {
        "variables": [
          {
            "value": "{{widgets.gather_GetAppointments.Digits}}",
            "key": "selectedAppointmentId"
          }
        ],
        "offset": {
          "x": -3030,
          "y": 3340
        }
      }
    },
    {
      "name": "function_AppointmentSchedule",
      "type": "run-function",
      "transitions": [
        {
          "next": "say_Appointments",
          "event": "success"
        },
        {
          "event": "fail"
        }
      ],
      "properties": {
        "service_sid": "ZSa16f5805f9dcedc9f47285e8a6626c94",
        "environment_sid": "ZE1fcc5d05fb47812e62b12d457cd8f76b",
        "offset": {
          "x": -3210,
          "y": 3620
        },
        "function_sid": "ZHe5ffb33f5969b4688b3f9e0fe5962e24",
        "parameters": [
          {
            "value": "{{widgets.gather_GetAppointments.Digits}}",
            "key": "AppointmentId"
          },
          {
            "value": "{{widgets.gather_PatientCode.Digits}}",
            "key": "PatientCodeSchedule"
          }
        ],
        "url": "https://validatepatient-4868.twil.io/appointment-schedule"
      }
    },
    {
      "name": "say_Appointments",
      "type": "say-play",
      "transitions": [
        {
          "next": "say_Godbay",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -3420,
          "y": 3870
        },
        "loop": 1,
        "say": "{{widgets.function_AppointmentSchedule.parsed.appointmentSchedule}}.",
        "language": "es-MX"
      }
    },
    {
      "name": "say_noNeedAppointment",
      "type": "say-play",
      "transitions": [
        {
          "next": "send_to_agent",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": 720,
          "y": -630
        },
        "loop": 1,
        "say": "Te redigiremos a asesor, espero podamos solucionar tu requerimiento.",
        "language": "es-MX"
      }
    },
    {
      "name": "Set_RetryInitialMenu",
      "type": "set-variables",
      "transitions": [
        {
          "next": "Split_RetryNumberCode",
          "event": "next"
        }
      ],
      "properties": {
        "variables": [
          {
            "value": "{%- if flow.variables.retryNumberCode -%}{{flow.variables.retryNumberCode | plus: 1}}\n{%- else -%}\n0\n{%- endif -%}",
            "key": "retryNumberCode"
          }
        ],
        "offset": {
          "x": 10,
          "y": -610
        }
      }
    },
    {
      "name": "Split_RetryNumberCode",
      "type": "split-based-on",
      "transitions": [
        {
          "next": "say_IncorrectOption",
          "event": "noMatch"
        },
        {
          "next": "say_RetryAskCode",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "If value greater_than 0",
              "arguments": [
                "{{flow.variables.retryNumberCode}}"
              ],
              "type": "greater_than",
              "value": "0"
            }
          ]
        }
      ],
      "properties": {
        "input": "{{flow.variables.retryNumberCode}}",
        "offset": {
          "x": 460,
          "y": -350
        }
      }
    },
    {
      "name": "say_RetryAskCode",
      "type": "say-play",
      "transitions": [
        {
          "next": "send_to_agent",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": 610,
          "y": -20
        },
        "loop": 1,
        "say": "Límite de reintentos excedido, te enviaremos con un asesor.",
        "language": "es-MX"
      }
    },
    {
      "name": "say_Godbay",
      "type": "say-play",
      "transitions": [
        {
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -3450,
          "y": 4110
        },
        "loop": 1,
        "say": "Tenga un felíz día, adios",
        "language": "es-MX"
      }
    },
    {
      "name": "say_NotAppointment",
      "type": "say-play",
      "transitions": [
        {
          "next": "send_to_agent3",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -2570,
          "y": 3310
        },
        "loop": 1,
        "say": "No hay citas disponibles en el momento, por lo tanto será redirigido a asesor.",
        "language": "es-MX"
      }
    },
    {
      "name": "Split_RetryNoinput",
      "type": "split-based-on",
      "transitions": [
        {
          "next": "gather_askCode",
          "event": "noMatch"
        },
        {
          "next": "Say_RetryNoinput",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "If value greater_than 0",
              "arguments": [
                "{{flow.variables.retryNoinput}}"
              ],
              "type": "greater_than",
              "value": "0"
            }
          ]
        }
      ],
      "properties": {
        "input": "{{flow.variables.retryNoinput}}",
        "offset": {
          "x": 1110,
          "y": -870
        }
      }
    },
    {
      "name": "Set_RetryNoInput",
      "type": "set-variables",
      "transitions": [
        {
          "next": "Split_RetryNoinput",
          "event": "next"
        }
      ],
      "properties": {
        "variables": [
          {
            "value": "{%- if flow.variables.retryNoinput -%}{{flow.variables.retryNoinput | plus: 1}}\n{%- else -%}\n0\n{%- endif -%}",
            "key": "retryNoinput"
          }
        ],
        "offset": {
          "x": 1170,
          "y": -1110
        }
      }
    },
    {
      "name": "Say_RetryNoinput",
      "type": "say-play",
      "transitions": [
        {
          "next": "send_to_agent",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": 1230,
          "y": -530
        },
        "loop": 1,
        "say": "Límite de reintentos excedido, te enviaremos con un asesor",
        "language": "es-MX"
      }
    },
    {
      "name": "say_IncorrectOption",
      "type": "say-play",
      "transitions": [
        {
          "next": "gather_askCode",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -400,
          "y": -920
        },
        "loop": 1,
        "say": "Opción Incorrecta",
        "language": "es-MX"
      }
    },
    {
      "name": "Set_RetryNoInput1",
      "type": "set-variables",
      "transitions": [
        {
          "next": "Split_RetryNoinput1",
          "event": "next"
        }
      ],
      "properties": {
        "variables": [
          {
            "value": "{%- if flow.variables.retryNoinput1 -%}{{flow.variables.retryNoinput1 | plus: 1}}\n{%- else -%}\n0\n{%- endif -%}",
            "key": "retryNoinput1"
          }
        ],
        "offset": {
          "x": -150,
          "y": -40
        }
      }
    },
    {
      "name": "Split_RetryNoinput1",
      "type": "split-based-on",
      "transitions": [
        {
          "next": "gather_PatientCode",
          "event": "noMatch"
        },
        {
          "next": "Say_RetryNoinput1",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "If value greater_than 0",
              "arguments": [
                "{{flow.variables.retryNoinput1}}"
              ],
              "type": "greater_than",
              "value": "0"
            }
          ]
        }
      ],
      "properties": {
        "input": "{{flow.variables.retryNoinput1}}",
        "offset": {
          "x": -210,
          "y": 200
        }
      }
    },
    {
      "name": "Say_RetryNoinput1",
      "type": "say-play",
      "transitions": [
        {
          "next": "send_to_agent",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -90,
          "y": 540
        },
        "loop": 1,
        "say": "Límite de reintentos excedido, te enviaremos con un asesor",
        "language": "es-MX"
      }
    },
    {
      "name": "Set_RetryNoInput2",
      "type": "set-variables",
      "transitions": [
        {
          "next": "Split_RetryNoinput2",
          "event": "next"
        }
      ],
      "properties": {
        "variables": [
          {
            "value": "{%- if flow.variables.retryNoinput2 -%}{{flow.variables.retryNoinput2 | plus: 1}}\n{%- else -%}\n0\n{%- endif -%}",
            "key": "retryNoinput2"
          }
        ],
        "offset": {
          "x": -220,
          "y": 1100
        }
      }
    },
    {
      "name": "Split_RetryNoinput2",
      "type": "split-based-on",
      "transitions": [
        {
          "next": "gather_confirmedNumber",
          "event": "noMatch"
        },
        {
          "next": "Say_RetryNoinput2",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "If value greater_than 0",
              "arguments": [
                "{{flow.variables.retryNoinput2}}"
              ],
              "type": "greater_than",
              "value": "0"
            }
          ]
        }
      ],
      "properties": {
        "input": "{{flow.variables.retryNoinput2}}",
        "offset": {
          "x": -280,
          "y": 1340
        }
      }
    },
    {
      "name": "Say_RetryNoinput2",
      "type": "say-play",
      "transitions": [
        {
          "next": "send_to_agent2",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -150,
          "y": 1620
        },
        "loop": 1,
        "say": "Límite de reintentos excedido, te enviaremos con un asesor",
        "language": "es-MX"
      }
    },
    {
      "name": "Set_RetryNoCondition",
      "type": "set-variables",
      "transitions": [
        {
          "next": "Split_RetryNoCondition",
          "event": "next"
        }
      ],
      "properties": {
        "variables": [
          {
            "value": "{%- if flow.variables.RetryNoCondition -%}{{flow.variables.RetryNoCondition | plus: 1}}\n{%- else -%}\n0\n{%- endif -%}",
            "key": "RetryNoCondition"
          }
        ],
        "offset": {
          "x": -1640,
          "y": 1390
        }
      }
    },
    {
      "name": "Split_RetryNoCondition",
      "type": "split-based-on",
      "transitions": [
        {
          "next": "say_IncorrectOption2",
          "event": "noMatch"
        },
        {
          "next": "Say_RetryNoCondition",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "If value greater_than 0",
              "arguments": [
                "{{flow.variables.RetryNoCondition}}"
              ],
              "type": "greater_than",
              "value": "0"
            }
          ]
        }
      ],
      "properties": {
        "input": "{{flow.variables.RetryNoCondition}}",
        "offset": {
          "x": -2400,
          "y": 1160
        }
      }
    },
    {
      "name": "say_IncorrectOption2",
      "type": "say-play",
      "transitions": [
        {
          "next": "gather_confirmedNumber",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -1520,
          "y": 900
        },
        "loop": 1,
        "say": "Opción Incorrecta",
        "language": "es-MX"
      }
    },
    {
      "name": "Say_RetryNoCondition",
      "type": "say-play",
      "transitions": [
        {
          "next": "send_to_agent2",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -1440,
          "y": 2010
        },
        "loop": 1,
        "say": "Límite de reintentos excedido, te enviaremos con un asesor.",
        "language": "es-MX"
      }
    },
    {
      "name": "Say_RetryNumber",
      "type": "say-play",
      "transitions": [
        {
          "next": "send_to_agent2",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -820,
          "y": 1980
        },
        "loop": 1,
        "say": "Límite de reintentos excedido, te enviaremos con un asesor",
        "language": "es-MX"
      }
    },
    {
      "name": "Say_RetryNoCondition1",
      "type": "say-play",
      "transitions": [
        {
          "next": "send_to_agent3",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -3020,
          "y": 2580
        },
        "loop": 1,
        "say": "Límite de reintentos excedido, te enviaremos con un asesor.",
        "language": "es-MX"
      }
    },
    {
      "name": "Set_RetryNoCondition1",
      "type": "set-variables",
      "transitions": [
        {
          "next": "Split_RetryNoCondition1",
          "event": "next"
        }
      ],
      "properties": {
        "variables": [
          {
            "value": "{%- if flow.variables.RetryNoCondition1 -%}{{flow.variables.RetryNoCondition1 | plus: 1}}\n{%- else -%}\n0\n{%- endif -%}",
            "key": "RetryNoCondition1"
          }
        ],
        "offset": {
          "x": -2770,
          "y": 1950
        }
      }
    },
    {
      "name": "Split_RetryNoCondition1",
      "type": "split-based-on",
      "transitions": [
        {
          "next": "say_IncorrectOption3",
          "event": "noMatch"
        },
        {
          "next": "Say_RetryNoCondition1",
          "event": "match",
          "conditions": [
            {
              "friendly_name": "If value greater_than 0",
              "arguments": [
                "{{flow.variables.RetryNoCondition1}}"
              ],
              "type": "greater_than",
              "value": "0"
            }
          ]
        }
      ],
      "properties": {
        "input": "{{flow.variables.RetryNoCondition1}}",
        "offset": {
          "x": -3020,
          "y": 2270
        }
      }
    },
    {
      "name": "say_IncorrectOption3",
      "type": "say-play",
      "transitions": [
        {
          "next": "split_GetCode",
          "event": "audioComplete"
        }
      ],
      "properties": {
        "voice": "Polly.Andres-Neural",
        "offset": {
          "x": -3230,
          "y": 1630
        },
        "loop": 1,
        "say": "Opción Incorrecta",
        "language": "es-MX"
      }
    }
  ],
  "initial_state": "Trigger",
  "flags": {
    "allow_concurrent_calls": true
  }
}