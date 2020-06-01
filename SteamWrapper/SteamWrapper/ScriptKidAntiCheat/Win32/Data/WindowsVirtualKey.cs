using System;
using System.ComponentModel;

namespace ScriptKidAntiCheat.Win32.Data
{
	// Token: 0x02000024 RID: 36
	public enum WindowsVirtualKey
	{
		// Token: 0x0400012B RID: 299
		[Description("Left mouse button")]
		VK_LBUTTON = 1,
		// Token: 0x0400012C RID: 300
		[Description("Right mouse button")]
		VK_RBUTTON,
		// Token: 0x0400012D RID: 301
		[Description("Control-break processing")]
		VK_CANCEL,
		// Token: 0x0400012E RID: 302
		[Description("Middle mouse button (three-button mouse)")]
		VK_MBUTTON,
		// Token: 0x0400012F RID: 303
		[Description("X1 mouse button")]
		VK_XBUTTON1,
		// Token: 0x04000130 RID: 304
		[Description("X2 mouse button")]
		VK_XBUTTON2,
		// Token: 0x04000131 RID: 305
		[Description("BACKSPACE key")]
		VK_BACK = 8,
		// Token: 0x04000132 RID: 306
		[Description("TAB key")]
		VK_TAB,
		// Token: 0x04000133 RID: 307
		[Description("CLEAR key")]
		VK_CLEAR = 12,
		// Token: 0x04000134 RID: 308
		[Description("ENTER key")]
		VK_RETURN,
		// Token: 0x04000135 RID: 309
		[Description("SHIFT key")]
		VK_SHIFT = 16,
		// Token: 0x04000136 RID: 310
		[Description("CTRL key")]
		VK_CONTROL,
		// Token: 0x04000137 RID: 311
		[Description("ALT key")]
		VK_MENU,
		// Token: 0x04000138 RID: 312
		[Description("PAUSE key")]
		VK_PAUSE,
		// Token: 0x04000139 RID: 313
		[Description("CAPS LOCK key")]
		VK_CAPITAL,
		// Token: 0x0400013A RID: 314
		[Description("IME Kana mode")]
		VK_KANA,
		// Token: 0x0400013B RID: 315
		[Description("IME Hanguel mode (maintained for compatibility; use VK_HANGUL)")]
		VK_HANGUEL = 21,
		// Token: 0x0400013C RID: 316
		[Description("IME Hangul mode")]
		VK_HANGUL = 21,
		// Token: 0x0400013D RID: 317
		[Description("IME Junja mode")]
		VK_JUNJA = 23,
		// Token: 0x0400013E RID: 318
		[Description("IME final mode")]
		VK_FINAL,
		// Token: 0x0400013F RID: 319
		[Description("IME Hanja mode")]
		VK_HANJA,
		// Token: 0x04000140 RID: 320
		[Description("IME Kanji mode")]
		VK_KANJI = 25,
		// Token: 0x04000141 RID: 321
		[Description("ESC key")]
		VK_ESCAPE = 27,
		// Token: 0x04000142 RID: 322
		[Description("IME convert")]
		VK_CONVERT,
		// Token: 0x04000143 RID: 323
		[Description("IME nonconvert")]
		VK_NONCONVERT,
		// Token: 0x04000144 RID: 324
		[Description("IME accept")]
		VK_ACCEPT,
		// Token: 0x04000145 RID: 325
		[Description("IME mode change request")]
		VK_MODECHANGE,
		// Token: 0x04000146 RID: 326
		[Description("SPACEBAR")]
		VK_SPACE,
		// Token: 0x04000147 RID: 327
		[Description("PAGE UP key")]
		VK_PRIOR,
		// Token: 0x04000148 RID: 328
		[Description("PAGE DOWN key")]
		VK_NEXT,
		// Token: 0x04000149 RID: 329
		[Description("END key")]
		VK_END,
		// Token: 0x0400014A RID: 330
		[Description("HOME key")]
		VK_HOME,
		// Token: 0x0400014B RID: 331
		[Description("LEFT ARROW key")]
		VK_LEFT,
		// Token: 0x0400014C RID: 332
		[Description("UP ARROW key")]
		VK_UP,
		// Token: 0x0400014D RID: 333
		[Description("RIGHT ARROW key")]
		VK_RIGHT,
		// Token: 0x0400014E RID: 334
		[Description("DOWN ARROW key")]
		VK_DOWN,
		// Token: 0x0400014F RID: 335
		[Description("SELECT key")]
		VK_SELECT,
		// Token: 0x04000150 RID: 336
		[Description("PRINT key")]
		VK_PRINT,
		// Token: 0x04000151 RID: 337
		[Description("EXECUTE key")]
		VK_EXECUTE,
		// Token: 0x04000152 RID: 338
		[Description("PRINT SCREEN key")]
		VK_SNAPSHOT,
		// Token: 0x04000153 RID: 339
		[Description("INS key")]
		VK_INSERT,
		// Token: 0x04000154 RID: 340
		[Description("DEL key")]
		VK_DELETE,
		// Token: 0x04000155 RID: 341
		[Description("HELP key")]
		VK_HELP,
		// Token: 0x04000156 RID: 342
		[Description("0 key")]
		K_0,
		// Token: 0x04000157 RID: 343
		[Description("1 key")]
		K_1,
		// Token: 0x04000158 RID: 344
		[Description("2 key")]
		K_2,
		// Token: 0x04000159 RID: 345
		[Description("3 key")]
		K_3,
		// Token: 0x0400015A RID: 346
		[Description("4 key")]
		K_4,
		// Token: 0x0400015B RID: 347
		[Description("5 key")]
		K_5,
		// Token: 0x0400015C RID: 348
		[Description("6 key")]
		K_6,
		// Token: 0x0400015D RID: 349
		[Description("7 key")]
		K_7,
		// Token: 0x0400015E RID: 350
		[Description("8 key")]
		K_8,
		// Token: 0x0400015F RID: 351
		[Description("9 key")]
		K_9,
		// Token: 0x04000160 RID: 352
		[Description("A key")]
		K_A = 65,
		// Token: 0x04000161 RID: 353
		[Description("B key")]
		K_B,
		// Token: 0x04000162 RID: 354
		[Description("C key")]
		K_C,
		// Token: 0x04000163 RID: 355
		[Description("D key")]
		K_D,
		// Token: 0x04000164 RID: 356
		[Description("E key")]
		K_E,
		// Token: 0x04000165 RID: 357
		[Description("F key")]
		K_F,
		// Token: 0x04000166 RID: 358
		[Description("G key")]
		K_G,
		// Token: 0x04000167 RID: 359
		[Description("H key")]
		K_H,
		// Token: 0x04000168 RID: 360
		[Description("I key")]
		K_I,
		// Token: 0x04000169 RID: 361
		[Description("J key")]
		K_J,
		// Token: 0x0400016A RID: 362
		[Description("K key")]
		K_K,
		// Token: 0x0400016B RID: 363
		[Description("L key")]
		K_L,
		// Token: 0x0400016C RID: 364
		[Description("M key")]
		K_M,
		// Token: 0x0400016D RID: 365
		[Description("N key")]
		K_N,
		// Token: 0x0400016E RID: 366
		[Description("O key")]
		K_O,
		// Token: 0x0400016F RID: 367
		[Description("P key")]
		K_P,
		// Token: 0x04000170 RID: 368
		[Description("Q key")]
		K_Q,
		// Token: 0x04000171 RID: 369
		[Description("R key")]
		K_R,
		// Token: 0x04000172 RID: 370
		[Description("S key")]
		K_S,
		// Token: 0x04000173 RID: 371
		[Description("T key")]
		K_T,
		// Token: 0x04000174 RID: 372
		[Description("U key")]
		K_U,
		// Token: 0x04000175 RID: 373
		[Description("V key")]
		K_V,
		// Token: 0x04000176 RID: 374
		[Description("W key")]
		K_W,
		// Token: 0x04000177 RID: 375
		[Description("X key")]
		K_X,
		// Token: 0x04000178 RID: 376
		[Description("Y key")]
		K_Y,
		// Token: 0x04000179 RID: 377
		[Description("Z key")]
		K_Z,
		// Token: 0x0400017A RID: 378
		[Description("Left Windows key (Natural keyboard)")]
		VK_LWIN,
		// Token: 0x0400017B RID: 379
		[Description("Right Windows key (Natural keyboard)")]
		VK_RWIN,
		// Token: 0x0400017C RID: 380
		[Description("Applications key (Natural keyboard)")]
		VK_APPS,
		// Token: 0x0400017D RID: 381
		[Description("Computer Sleep key")]
		VK_SLEEP = 95,
		// Token: 0x0400017E RID: 382
		[Description("Numeric keypad 0 key")]
		VK_NUMPAD0,
		// Token: 0x0400017F RID: 383
		[Description("Numeric keypad 1 key")]
		VK_NUMPAD1,
		// Token: 0x04000180 RID: 384
		[Description("Numeric keypad 2 key")]
		VK_NUMPAD2,
		// Token: 0x04000181 RID: 385
		[Description("Numeric keypad 3 key")]
		VK_NUMPAD3,
		// Token: 0x04000182 RID: 386
		[Description("Numeric keypad 4 key")]
		VK_NUMPAD4,
		// Token: 0x04000183 RID: 387
		[Description("Numeric keypad 5 key")]
		VK_NUMPAD5,
		// Token: 0x04000184 RID: 388
		[Description("Numeric keypad 6 key")]
		VK_NUMPAD6,
		// Token: 0x04000185 RID: 389
		[Description("Numeric keypad 7 key")]
		VK_NUMPAD7,
		// Token: 0x04000186 RID: 390
		[Description("Numeric keypad 8 key")]
		VK_NUMPAD8,
		// Token: 0x04000187 RID: 391
		[Description("Numeric keypad 9 key")]
		VK_NUMPAD9,
		// Token: 0x04000188 RID: 392
		[Description("Multiply key")]
		VK_MULTIPLY,
		// Token: 0x04000189 RID: 393
		[Description("Add key")]
		VK_ADD,
		// Token: 0x0400018A RID: 394
		[Description("Separator key")]
		VK_SEPARATOR,
		// Token: 0x0400018B RID: 395
		[Description("Subtract key")]
		VK_SUBTRACT,
		// Token: 0x0400018C RID: 396
		[Description("Decimal key")]
		VK_DECIMAL,
		// Token: 0x0400018D RID: 397
		[Description("Divide key")]
		VK_DIVIDE,
		// Token: 0x0400018E RID: 398
		[Description("F1 key")]
		VK_F1,
		// Token: 0x0400018F RID: 399
		[Description("F2 key")]
		VK_F2,
		// Token: 0x04000190 RID: 400
		[Description("F3 key")]
		VK_F3,
		// Token: 0x04000191 RID: 401
		[Description("F4 key")]
		VK_F4,
		// Token: 0x04000192 RID: 402
		[Description("F5 key")]
		VK_F5,
		// Token: 0x04000193 RID: 403
		[Description("F6 key")]
		VK_F6,
		// Token: 0x04000194 RID: 404
		[Description("F7 key")]
		VK_F7,
		// Token: 0x04000195 RID: 405
		[Description("F8 key")]
		VK_F8,
		// Token: 0x04000196 RID: 406
		[Description("F9 key")]
		VK_F9,
		// Token: 0x04000197 RID: 407
		[Description("F10 key")]
		VK_F10,
		// Token: 0x04000198 RID: 408
		[Description("F11 key")]
		VK_F11,
		// Token: 0x04000199 RID: 409
		[Description("F12 key")]
		VK_F12,
		// Token: 0x0400019A RID: 410
		[Description("F13 key")]
		VK_F13,
		// Token: 0x0400019B RID: 411
		[Description("F14 key")]
		VK_F14,
		// Token: 0x0400019C RID: 412
		[Description("F15 key")]
		VK_F15,
		// Token: 0x0400019D RID: 413
		[Description("F16 key")]
		VK_F16,
		// Token: 0x0400019E RID: 414
		[Description("F17 key")]
		VK_F17,
		// Token: 0x0400019F RID: 415
		[Description("F18 key")]
		VK_F18,
		// Token: 0x040001A0 RID: 416
		[Description("F19 key")]
		VK_F19,
		// Token: 0x040001A1 RID: 417
		[Description("F20 key")]
		VK_F20,
		// Token: 0x040001A2 RID: 418
		[Description("F21 key")]
		VK_F21,
		// Token: 0x040001A3 RID: 419
		[Description("F22 key")]
		VK_F22,
		// Token: 0x040001A4 RID: 420
		[Description("F23 key")]
		VK_F23,
		// Token: 0x040001A5 RID: 421
		[Description("F24 key")]
		VK_F24,
		// Token: 0x040001A6 RID: 422
		[Description("NUM LOCK key")]
		VK_NUMLOCK = 144,
		// Token: 0x040001A7 RID: 423
		[Description("SCROLL LOCK key")]
		VK_SCROLL,
		// Token: 0x040001A8 RID: 424
		[Description("Left SHIFT key")]
		VK_LSHIFT = 160,
		// Token: 0x040001A9 RID: 425
		[Description("Right SHIFT key")]
		VK_RSHIFT,
		// Token: 0x040001AA RID: 426
		[Description("Left CONTROL key")]
		VK_LCONTROL,
		// Token: 0x040001AB RID: 427
		[Description("Right CONTROL key")]
		VK_RCONTROL,
		// Token: 0x040001AC RID: 428
		[Description("Left MENU key")]
		VK_LMENU,
		// Token: 0x040001AD RID: 429
		[Description("Right MENU key")]
		VK_RMENU,
		// Token: 0x040001AE RID: 430
		[Description("Browser Back key")]
		VK_BROWSER_BACK,
		// Token: 0x040001AF RID: 431
		[Description("Browser Forward key")]
		VK_BROWSER_FORWARD,
		// Token: 0x040001B0 RID: 432
		[Description("Browser Refresh key")]
		VK_BROWSER_REFRESH,
		// Token: 0x040001B1 RID: 433
		[Description("Browser Stop key")]
		VK_BROWSER_STOP,
		// Token: 0x040001B2 RID: 434
		[Description("Browser Search key")]
		VK_BROWSER_SEARCH,
		// Token: 0x040001B3 RID: 435
		[Description("Browser Favorites key")]
		VK_BROWSER_FAVORITES,
		// Token: 0x040001B4 RID: 436
		[Description("Browser Start and Home key")]
		VK_BROWSER_HOME,
		// Token: 0x040001B5 RID: 437
		[Description("Volume Mute key")]
		VK_VOLUME_MUTE,
		// Token: 0x040001B6 RID: 438
		[Description("Volume Down key")]
		VK_VOLUME_DOWN,
		// Token: 0x040001B7 RID: 439
		[Description("Volume Up key")]
		VK_VOLUME_UP,
		// Token: 0x040001B8 RID: 440
		[Description("Next Track key")]
		VK_MEDIA_NEXT_TRACK,
		// Token: 0x040001B9 RID: 441
		[Description("Previous Track key")]
		VK_MEDIA_PREV_TRACK,
		// Token: 0x040001BA RID: 442
		[Description("Stop Media key")]
		VK_MEDIA_STOP,
		// Token: 0x040001BB RID: 443
		[Description("Play/Pause Media key")]
		VK_MEDIA_PLAY_PAUSE,
		// Token: 0x040001BC RID: 444
		[Description("Start Mail key")]
		VK_LAUNCH_MAIL,
		// Token: 0x040001BD RID: 445
		[Description("Select Media key")]
		VK_LAUNCH_MEDIA_SELECT,
		// Token: 0x040001BE RID: 446
		[Description("Start Application 1 key")]
		VK_LAUNCH_APP1,
		// Token: 0x040001BF RID: 447
		[Description("Start Application 2 key")]
		VK_LAUNCH_APP2,
		// Token: 0x040001C0 RID: 448
		[Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key")]
		VK_OEM_1 = 186,
		// Token: 0x040001C1 RID: 449
		[Description("For any country/region, the '+' key")]
		VK_OEM_PLUS,
		// Token: 0x040001C2 RID: 450
		[Description("For any country/region, the ',' key")]
		VK_OEM_COMMA,
		// Token: 0x040001C3 RID: 451
		[Description("For any country/region, the '-' key")]
		VK_OEM_MINUS,
		// Token: 0x040001C4 RID: 452
		[Description("For any country/region, the '.' key")]
		VK_OEM_PERIOD,
		// Token: 0x040001C5 RID: 453
		[Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key")]
		VK_OEM_2,
		// Token: 0x040001C6 RID: 454
		[Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '`~' key")]
		VK_OEM_3,
		// Token: 0x040001C7 RID: 455
		[Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key")]
		VK_OEM_4 = 219,
		// Token: 0x040001C8 RID: 456
		[Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\\|' key")]
		VK_OEM_5,
		// Token: 0x040001C9 RID: 457
		[Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key")]
		VK_OEM_6,
		// Token: 0x040001CA RID: 458
		[Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key")]
		VK_OEM_7,
		// Token: 0x040001CB RID: 459
		[Description("Used for miscellaneous characters; it can vary by keyboard.")]
		VK_OEM_8,
		// Token: 0x040001CC RID: 460
		[Description("Either the angle bracket key or the backslash key on the RT 102-key keyboard")]
		VK_OEM_102 = 226,
		// Token: 0x040001CD RID: 461
		[Description("IME PROCESS key")]
		VK_PROCESSKEY = 229,
		// Token: 0x040001CE RID: 462
		[Description("Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP")]
		VK_PACKET = 231,
		// Token: 0x040001CF RID: 463
		[Description("Attn key")]
		VK_ATTN = 246,
		// Token: 0x040001D0 RID: 464
		[Description("CrSel key")]
		VK_CRSEL,
		// Token: 0x040001D1 RID: 465
		[Description("ExSel key")]
		VK_EXSEL,
		// Token: 0x040001D2 RID: 466
		[Description("Erase EOF key")]
		VK_EREOF,
		// Token: 0x040001D3 RID: 467
		[Description("Play key")]
		VK_PLAY,
		// Token: 0x040001D4 RID: 468
		[Description("Zoom key")]
		VK_ZOOM,
		// Token: 0x040001D5 RID: 469
		[Description("PA1 key")]
		VK_PA1 = 253,
		// Token: 0x040001D6 RID: 470
		[Description("Clear key")]
		VK_OEM_CLEAR
	}
}
