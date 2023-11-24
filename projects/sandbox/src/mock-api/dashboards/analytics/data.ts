import { DateTime } from "@ngx-ontrial/core";

/* Get the current instant */
const now = DateTime.now();

export const analytics = {
	visitors: {
		series: {
			'this-year': [
				{
					name: 'Visitors',
					data: [
						{
							x: now.subtract({ months: 12 }).add({ days: 1 }).toJSDate(),
							y: 4884,
						},
						{
							x: now.subtract({ months: 12 }).add({ days: 4 }).toJSDate(),
							y: 5351,
						},
						{
							x: now.subtract({ months: 12 }).add({ days: 7 }).toJSDate(),
							y: 5293,
						},
						{
							x: now.subtract({ months: 12 }).add({ days: 10 }).toJSDate(),
							y: 4908,
						},
						{
							x: now.subtract({ months: 12 }).add({ days: 13 }).toJSDate(),
							y: 5027,
						},
						{
							x: now.subtract({ months: 12 }).add({ days: 16 }).toJSDate(),
							y: 4837,
						},
						{
							x: now.subtract({ months: 12 }).add({ days: 19 }).toJSDate(),
							y: 4484,
						},
						{
							x: now.subtract({ months: 12 }).add({ days: 22 }).toJSDate(),
							y: 4071,
						},
						{
							x: now.subtract({ months: 12 }).add({ days: 25 }).toJSDate(),
							y: 4124,
						},
						{
							x: now.subtract({ months: 12 }).add({ days: 28 }).toJSDate(),
							y: 4563,
						},
						{
							x: now.subtract({ months: 11 }).add({ days: 1 }).toJSDate(),
							y: 3820,
						},
						{
							x: now.subtract({ months: 11 }).add({ days: 4 }).toJSDate(),
							y: 3968,
						},
						{
							x: now.subtract({ months: 11 }).add({ days: 7 }).toJSDate(),
							y: 4102,
						},
						{
							x: now.subtract({ months: 11 }).add({ days: 10 }).toJSDate(),
							y: 3941,
						},
						{
							x: now.subtract({ months: 11 }).add({ days: 13 }).toJSDate(),
							y: 3566,
						},
						{
							x: now.subtract({ months: 11 }).add({ days: 16 }).toJSDate(),
							y: 3853,
						},
						{
							x: now.subtract({ months: 11 }).add({ days: 19 }).toJSDate(),
							y: 3853,
						},
						{
							x: now.subtract({ months: 11 }).add({ days: 22 }).toJSDate(),
							y: 4069,
						},
						{
							x: now.subtract({ months: 11 }).add({ days: 25 }).toJSDate(),
							y: 3879,
						},
						{
							x: now.subtract({ months: 11 }).add({ days: 28 }).toJSDate(),
							y: 4298,
						},
						{
							x: now.subtract({ months: 10 }).add({ days: 1 }).toJSDate(),
							y: 4355,
						},
						{
							x: now.subtract({ months: 10 }).add({ days: 4 }).toJSDate(),
							y: 4065,
						},
						{
							x: now.subtract({ months: 10 }).add({ days: 7 }).toJSDate(),
							y: 3650,
						},
						{
							x: now.subtract({ months: 10 }).add({ days: 10 }).toJSDate(),
							y: 3379,
						},
						{
							x: now.subtract({ months: 10 }).add({ days: 13 }).toJSDate(),
							y: 3191,
						},
						{
							x: now.subtract({ months: 10 }).add({ days: 16 }).toJSDate(),
							y: 2968,
						},
						{
							x: now.subtract({ months: 10 }).add({ days: 19 }).toJSDate(),
							y: 2957,
						},
						{
							x: now.subtract({ months: 10 }).add({ days: 22 }).toJSDate(),
							y: 3313,
						},
						{
							x: now.subtract({ months: 10 }).add({ days: 25 }).toJSDate(),
							y: 3708,
						},
						{
							x: now.subtract({ months: 10 }).add({ days: 28 }).toJSDate(),
							y: 3586,
						},
						{
							x: now.subtract({ months: 9 }).add({ days: 1 }).toJSDate(),
							y: 3965,
						},
						{
							x: now.subtract({ months: 9 }).add({ days: 4 }).toJSDate(),
							y: 3901,
						},
						{
							x: now.subtract({ months: 9 }).add({ days: 7 }).toJSDate(),
							y: 3410,
						},
						{
							x: now.subtract({ months: 9 }).add({ days: 10 }).toJSDate(),
							y: 3748,
						},
						{
							x: now.subtract({ months: 9 }).add({ days: 13 }).toJSDate(),
							y: 3929,
						},
						{
							x: now.subtract({ months: 9 }).add({ days: 16 }).toJSDate(),
							y: 3846,
						},
						{
							x: now.subtract({ months: 9 }).add({ days: 19 }).toJSDate(),
							y: 3771,
						},
						{
							x: now.subtract({ months: 9 }).add({ days: 22 }).toJSDate(),
							y: 4015,
						},
						{
							x: now.subtract({ months: 9 }).add({ days: 25 }).toJSDate(),
							y: 3589,
						},
						{
							x: now.subtract({ months: 9 }).add({ days: 28 }).toJSDate(),
							y: 3150,
						},
						{
							x: now.subtract({ months: 8 }).add({ days: 1 }).toJSDate(),
							y: 3050,
						},
						{
							x: now.subtract({ months: 8 }).add({ days: 4 }).toJSDate(),
							y: 2574,
						},
						{
							x: now.subtract({ months: 8 }).add({ days: 7 }).toJSDate(),
							y: 2823,
						},
						{
							x: now.subtract({ months: 8 }).add({ days: 10 }).toJSDate(),
							y: 2848,
						},
						{
							x: now.subtract({ months: 8 }).add({ days: 13 }).toJSDate(),
							y: 3000,
						},
						{
							x: now.subtract({ months: 8 }).add({ days: 16 }).toJSDate(),
							y: 3216,
						},
						{
							x: now.subtract({ months: 8 }).add({ days: 19 }).toJSDate(),
							y: 3299,
						},
						{
							x: now.subtract({ months: 8 }).add({ days: 22 }).toJSDate(),
							y: 3768,
						},
						{
							x: now.subtract({ months: 8 }).add({ days: 25 }).toJSDate(),
							y: 3524,
						},
						{
							x: now.subtract({ months: 8 }).add({ days: 28 }).toJSDate(),
							y: 3918,
						},
						{
							x: now.subtract({ months: 7 }).add({ days: 1 }).toJSDate(),
							y: 4145,
						},
						{
							x: now.subtract({ months: 7 }).add({ days: 4 }).toJSDate(),
							y: 4378,
						},
						{
							x: now.subtract({ months: 7 }).add({ days: 7 }).toJSDate(),
							y: 3941,
						},
						{
							x: now.subtract({ months: 7 }).add({ days: 10 }).toJSDate(),
							y: 3932,
						},
						{
							x: now.subtract({ months: 7 }).add({ days: 13 }).toJSDate(),
							y: 4380,
						},
						{
							x: now.subtract({ months: 7 }).add({ days: 16 }).toJSDate(),
							y: 4243,
						},
						{
							x: now.subtract({ months: 7 }).add({ days: 19 }).toJSDate(),
							y: 4367,
						},
						{
							x: now.subtract({ months: 7 }).add({ days: 22 }).toJSDate(),
							y: 3879,
						},
						{
							x: now.subtract({ months: 7 }).add({ days: 25 }).toJSDate(),
							y: 4357,
						},
						{
							x: now.subtract({ months: 7 }).add({ days: 28 }).toJSDate(),
							y: 4181,
						},
						{
							x: now.subtract({ months: 6 }).add({ days: 1 }).toJSDate(),
							y: 4619,
						},
						{
							x: now.subtract({ months: 6 }).add({ days: 4 }).toJSDate(),
							y: 4769,
						},
						{
							x: now.subtract({ months: 6 }).add({ days: 7 }).toJSDate(),
							y: 4901,
						},
						{
							x: now.subtract({ months: 6 }).add({ days: 10 }).toJSDate(),
							y: 4640,
						},
						{
							x: now.subtract({ months: 6 }).add({ days: 13 }).toJSDate(),
							y: 5128,
						},
						{
							x: now.subtract({ months: 6 }).add({ days: 16 }).toJSDate(),
							y: 5015,
						},
						{
							x: now.subtract({ months: 6 }).add({ days: 19 }).toJSDate(),
							y: 5360,
						},
						{
							x: now.subtract({ months: 6 }).add({ days: 22 }).toJSDate(),
							y: 5608,
						},
						{
							x: now.subtract({ months: 6 }).add({ days: 25 }).toJSDate(),
							y: 5272,
						},
						{
							x: now.subtract({ months: 6 }).add({ days: 28 }).toJSDate(),
							y: 5660,
						},
						{
							x: now.subtract({ months: 5 }).add({ days: 1 }).toJSDate(),
							y: 5836,
						},
						{
							x: now.subtract({ months: 5 }).add({ days: 4 }).toJSDate(),
							y: 5659,
						},
						{
							x: now.subtract({ months: 5 }).add({ days: 7 }).toJSDate(),
							y: 5575,
						},
						{
							x: now.subtract({ months: 5 }).add({ days: 10 }).toJSDate(),
							y: 5474,
						},
						{
							x: now.subtract({ months: 5 }).add({ days: 13 }).toJSDate(),
							y: 5427,
						},
						{
							x: now.subtract({ months: 5 }).add({ days: 16 }).toJSDate(),
							y: 5865,
						},
						{
							x: now.subtract({ months: 5 }).add({ days: 19 }).toJSDate(),
							y: 5700,
						},
						{
							x: now.subtract({ months: 5 }).add({ days: 22 }).toJSDate(),
							y: 6052,
						},
						{
							x: now.subtract({ months: 5 }).add({ days: 25 }).toJSDate(),
							y: 5760,
						},
						{
							x: now.subtract({ months: 5 }).add({ days: 28 }).toJSDate(),
							y: 5648,
						},
						{
							x: now.subtract({ months: 4 }).add({ days: 1 }).toJSDate(),
							y: 5435,
						},
						{
							x: now.subtract({ months: 4 }).add({ days: 4 }).toJSDate(),
							y: 5239,
						},
						{
							x: now.subtract({ months: 4 }).add({ days: 7 }).toJSDate(),
							y: 5452,
						},
						{
							x: now.subtract({ months: 4 }).add({ days: 10 }).toJSDate(),
							y: 5416,
						},
						{
							x: now.subtract({ months: 4 }).add({ days: 13 }).toJSDate(),
							y: 5195,
						},
						{
							x: now.subtract({ months: 4 }).add({ days: 16 }).toJSDate(),
							y: 5119,
						},
						{
							x: now.subtract({ months: 4 }).add({ days: 19 }).toJSDate(),
							y: 4635,
						},
						{
							x: now.subtract({ months: 4 }).add({ days: 22 }).toJSDate(),
							y: 4833,
						},
						{
							x: now.subtract({ months: 4 }).add({ days: 25 }).toJSDate(),
							y: 4584,
						},
						{
							x: now.subtract({ months: 4 }).add({ days: 28 }).toJSDate(),
							y: 4822,
						},
						{
							x: now.subtract({ months: 3 }).add({ days: 1 }).toJSDate(),
							y: 4582,
						},
						{
							x: now.subtract({ months: 3 }).add({ days: 4 }).toJSDate(),
							y: 4348,
						},
						{
							x: now.subtract({ months: 3 }).add({ days: 7 }).toJSDate(),
							y: 4132,
						},
						{
							x: now.subtract({ months: 3 }).add({ days: 10 }).toJSDate(),
							y: 4099,
						},
						{
							x: now.subtract({ months: 3 }).add({ days: 13 }).toJSDate(),
							y: 3849,
						},
						{
							x: now.subtract({ months: 3 }).add({ days: 16 }).toJSDate(),
							y: 4010,
						},
						{
							x: now.subtract({ months: 3 }).add({ days: 19 }).toJSDate(),
							y: 4486,
						},
						{
							x: now.subtract({ months: 3 }).add({ days: 22 }).toJSDate(),
							y: 4403,
						},
						{
							x: now.subtract({ months: 3 }).add({ days: 25 }).toJSDate(),
							y: 4141,
						},
						{
							x: now.subtract({ months: 3 }).add({ days: 28 }).toJSDate(),
							y: 3780,
						},
						{
							x: now.subtract({ months: 2 }).add({ days: 1 }).toJSDate(),
							y: 3524,
						},
						{
							x: now.subtract({ months: 2 }).add({ days: 4 }).toJSDate(),
							y: 3212,
						},
						{
							x: now.subtract({ months: 2 }).add({ days: 7 }).toJSDate(),
							y: 3568,
						},
						{
							x: now.subtract({ months: 2 }).add({ days: 10 }).toJSDate(),
							y: 3800,
						},
						{
							x: now.subtract({ months: 2 }).add({ days: 13 }).toJSDate(),
							y: 3796,
						},
						{
							x: now.subtract({ months: 2 }).add({ days: 16 }).toJSDate(),
							y: 3870,
						},
						{
							x: now.subtract({ months: 2 }).add({ days: 19 }).toJSDate(),
							y: 3745,
						},
						{
							x: now.subtract({ months: 2 }).add({ days: 22 }).toJSDate(),
							y: 3751,
						},
						{
							x: now.subtract({ months: 2 }).add({ days: 25 }).toJSDate(),
							y: 3310,
						},
						{
							x: now.subtract({ months: 2 }).add({ days: 28 }).toJSDate(),
							y: 3509,
						},
						{
							x: now.subtract({ months: 1 }).add({ days: 1 }).toJSDate(),
							y: 3187,
						},
						{
							x: now.subtract({ months: 1 }).add({ days: 4 }).toJSDate(),
							y: 2918,
						},
						{
							x: now.subtract({ months: 1 }).add({ days: 7 }).toJSDate(),
							y: 3191,
						},
						{
							x: now.subtract({ months: 1 }).add({ days: 10 }).toJSDate(),
							y: 3437,
						},
						{
							x: now.subtract({ months: 1 }).add({ days: 13 }).toJSDate(),
							y: 3291,
						},
						{
							x: now.subtract({ months: 1 }).add({ days: 16 }).toJSDate(),
							y: 3317,
						},
						{
							x: now.subtract({ months: 1 }).add({ days: 19 }).toJSDate(),
							y: 3716,
						},
						{
							x: now.subtract({ months: 1 }).add({ days: 22 }).toJSDate(),
							y: 3260,
						},
						{
							x: now.subtract({ months: 1 }).add({ days: 25 }).toJSDate(),
							y: 3694,
						},
						{
							x: now.subtract({ months: 1 }).add({ days: 28 }).toJSDate(),
							y: 3598,
						},
					],
				},
			],
			'last-year': [
				{
					name: 'Visitors',
					data: [
						{
							x: now.subtract({ months: 24 }).add({ days: 1 }).toJSDate(),
							y: 2021,
						},
						{
							x: now.subtract({ months: 24 }).add({ days: 4 }).toJSDate(),
							y: 1749,
						},
						{
							x: now.subtract({ months: 24 }).add({ days: 7 }).toJSDate(),
							y: 1654,
						},
						{
							x: now.subtract({ months: 24 }).add({ days: 10 }).toJSDate(),
							y: 1900,
						},
						{
							x: now.subtract({ months: 24 }).add({ days: 13 }).toJSDate(),
							y: 1647,
						},
						{
							x: now.subtract({ months: 24 }).add({ days: 16 }).toJSDate(),
							y: 1315,
						},
						{
							x: now.subtract({ months: 24 }).add({ days: 19 }).toJSDate(),
							y: 1807,
						},
						{
							x: now.subtract({ months: 24 }).add({ days: 22 }).toJSDate(),
							y: 1793,
						},
						{
							x: now.subtract({ months: 24 }).add({ days: 25 }).toJSDate(),
							y: 1892,
						},
						{
							x: now.subtract({ months: 24 }).add({ days: 28 }).toJSDate(),
							y: 1846,
						},
						{
							x: now.subtract({ months: 23 }).add({ days: 1 }).toJSDate(),
							y: 1804,
						},
						{
							x: now.subtract({ months: 23 }).add({ days: 4 }).toJSDate(),
							y: 1778,
						},
						{
							x: now.subtract({ months: 23 }).add({ days: 7 }).toJSDate(),
							y: 2015,
						},
						{
							x: now.subtract({ months: 23 }).add({ days: 10 }).toJSDate(),
							y: 1892,
						},
						{
							x: now.subtract({ months: 23 }).add({ days: 13 }).toJSDate(),
							y: 1708,
						},
						{
							x: now.subtract({ months: 23 }).add({ days: 16 }).toJSDate(),
							y: 1711,
						},
						{
							x: now.subtract({ months: 23 }).add({ days: 19 }).toJSDate(),
							y: 1570,
						},
						{
							x: now.subtract({ months: 23 }).add({ days: 22 }).toJSDate(),
							y: 1507,
						},
						{
							x: now.subtract({ months: 23 }).add({ days: 25 }).toJSDate(),
							y: 1451,
						},
						{
							x: now.subtract({ months: 23 }).add({ days: 28 }).toJSDate(),
							y: 1522,
						},
						{
							x: now.subtract({ months: 22 }).add({ days: 1 }).toJSDate(),
							y: 1977,
						},
						{
							x: now.subtract({ months: 22 }).add({ days: 4 }).toJSDate(),
							y: 2367,
						},
						{
							x: now.subtract({ months: 22 }).add({ days: 7 }).toJSDate(),
							y: 2798,
						},
						{
							x: now.subtract({ months: 22 }).add({ days: 10 }).toJSDate(),
							y: 3080,
						},
						{
							x: now.subtract({ months: 22 }).add({ days: 13 }).toJSDate(),
							y: 2856,
						},
						{
							x: now.subtract({ months: 22 }).add({ days: 16 }).toJSDate(),
							y: 2745,
						},
						{
							x: now.subtract({ months: 22 }).add({ days: 19 }).toJSDate(),
							y: 2750,
						},
						{
							x: now.subtract({ months: 22 }).add({ days: 22 }).toJSDate(),
							y: 2728,
						},
						{
							x: now.subtract({ months: 22 }).add({ days: 25 }).toJSDate(),
							y: 2436,
						},
						{
							x: now.subtract({ months: 22 }).add({ days: 28 }).toJSDate(),
							y: 2289,
						},
						{
							x: now.subtract({ months: 21 }).add({ days: 1 }).toJSDate(),
							y: 2804,
						},
						{
							x: now.subtract({ months: 21 }).add({ days: 4 }).toJSDate(),
							y: 2777,
						},
						{
							x: now.subtract({ months: 21 }).add({ days: 7 }).toJSDate(),
							y: 3024,
						},
						{
							x: now.subtract({ months: 21 }).add({ days: 10 }).toJSDate(),
							y: 2657,
						},
						{
							x: now.subtract({ months: 21 }).add({ days: 13 }).toJSDate(),
							y: 2218,
						},
						{
							x: now.subtract({ months: 21 }).add({ days: 16 }).toJSDate(),
							y: 1964,
						},
						{
							x: now.subtract({ months: 21 }).add({ days: 19 }).toJSDate(),
							y: 1674,
						},
						{
							x: now.subtract({ months: 21 }).add({ days: 22 }).toJSDate(),
							y: 1721,
						},
						{
							x: now.subtract({ months: 21 }).add({ days: 25 }).toJSDate(),
							y: 2005,
						},
						{
							x: now.subtract({ months: 21 }).add({ days: 28 }).toJSDate(),
							y: 1613,
						},
						{
							x: now.subtract({ months: 20 }).add({ days: 1 }).toJSDate(),
							y: 1071,
						},
						{
							x: now.subtract({ months: 20 }).add({ days: 4 }).toJSDate(),
							y: 1079,
						},
						{
							x: now.subtract({ months: 20 }).add({ days: 7 }).toJSDate(),
							y: 1133,
						},
						{
							x: now.subtract({ months: 20 }).add({ days: 10 }).toJSDate(),
							y: 1536,
						},
						{
							x: now.subtract({ months: 20 }).add({ days: 13 }).toJSDate(),
							y: 2016,
						},
						{
							x: now.subtract({ months: 20 }).add({ days: 16 }).toJSDate(),
							y: 2256,
						},
						{
							x: now.subtract({ months: 20 }).add({ days: 19 }).toJSDate(),
							y: 1934,
						},
						{
							x: now.subtract({ months: 20 }).add({ days: 22 }).toJSDate(),
							y: 1832,
						},
						{
							x: now.subtract({ months: 20 }).add({ days: 25 }).toJSDate(),
							y: 2075,
						},
						{
							x: now.subtract({ months: 20 }).add({ days: 28 }).toJSDate(),
							y: 1709,
						},
						{
							x: now.subtract({ months: 19 }).add({ days: 1 }).toJSDate(),
							y: 1831,
						},
						{
							x: now.subtract({ months: 19 }).add({ days: 4 }).toJSDate(),
							y: 1434,
						},
						{
							x: now.subtract({ months: 19 }).add({ days: 7 }).toJSDate(),
							y: 1293,
						},
						{
							x: now.subtract({ months: 19 }).add({ days: 10 }).toJSDate(),
							y: 1064,
						},
						{
							x: now.subtract({ months: 19 }).add({ days: 13 }).toJSDate(),
							y: 1080,
						},
						{
							x: now.subtract({ months: 19 }).add({ days: 16 }).toJSDate(),
							y: 1032,
						},
						{
							x: now.subtract({ months: 19 }).add({ days: 19 }).toJSDate(),
							y: 1280,
						},
						{
							x: now.subtract({ months: 19 }).add({ days: 22 }).toJSDate(),
							y: 1344,
						},
						{
							x: now.subtract({ months: 19 }).add({ days: 25 }).toJSDate(),
							y: 1835,
						},
						{
							x: now.subtract({ months: 19 }).add({ days: 28 }).toJSDate(),
							y: 2287,
						},
						{
							x: now.subtract({ months: 18 }).add({ days: 1 }).toJSDate(),
							y: 2692,
						},
						{
							x: now.subtract({ months: 18 }).add({ days: 4 }).toJSDate(),
							y: 2250,
						},
						{
							x: now.subtract({ months: 18 }).add({ days: 7 }).toJSDate(),
							y: 1814,
						},
						{
							x: now.subtract({ months: 18 }).add({ days: 10 }).toJSDate(),
							y: 1906,
						},
						{
							x: now.subtract({ months: 18 }).add({ days: 13 }).toJSDate(),
							y: 1973,
						},
						{
							x: now.subtract({ months: 18 }).add({ days: 16 }).toJSDate(),
							y: 1882,
						},
						{
							x: now.subtract({ months: 18 }).add({ days: 19 }).toJSDate(),
							y: 2333,
						},
						{
							x: now.subtract({ months: 18 }).add({ days: 22 }).toJSDate(),
							y: 2048,
						},
						{
							x: now.subtract({ months: 18 }).add({ days: 25 }).toJSDate(),
							y: 2547,
						},
						{
							x: now.subtract({ months: 18 }).add({ days: 28 }).toJSDate(),
							y: 2884,
						},
						{
							x: now.subtract({ months: 17 }).add({ days: 1 }).toJSDate(),
							y: 2771,
						},
						{
							x: now.subtract({ months: 17 }).add({ days: 4 }).toJSDate(),
							y: 2522,
						},
						{
							x: now.subtract({ months: 17 }).add({ days: 7 }).toJSDate(),
							y: 2543,
						},
						{
							x: now.subtract({ months: 17 }).add({ days: 10 }).toJSDate(),
							y: 2413,
						},
						{
							x: now.subtract({ months: 17 }).add({ days: 13 }).toJSDate(),
							y: 2002,
						},
						{
							x: now.subtract({ months: 17 }).add({ days: 16 }).toJSDate(),
							y: 1838,
						},
						{
							x: now.subtract({ months: 17 }).add({ days: 19 }).toJSDate(),
							y: 1830,
						},
						{
							x: now.subtract({ months: 17 }).add({ days: 22 }).toJSDate(),
							y: 1872,
						},
						{
							x: now.subtract({ months: 17 }).add({ days: 25 }).toJSDate(),
							y: 2246,
						},
						{
							x: now.subtract({ months: 17 }).add({ days: 28 }).toJSDate(),
							y: 2171,
						},
						{
							x: now.subtract({ months: 16 }).add({ days: 1 }).toJSDate(),
							y: 2988,
						},
						{
							x: now.subtract({ months: 16 }).add({ days: 4 }).toJSDate(),
							y: 2694,
						},
						{
							x: now.subtract({ months: 16 }).add({ days: 7 }).toJSDate(),
							y: 2806,
						},
						{
							x: now.subtract({ months: 16 }).add({ days: 10 }).toJSDate(),
							y: 3040,
						},
						{
							x: now.subtract({ months: 16 }).add({ days: 13 }).toJSDate(),
							y: 2898,
						},
						{
							x: now.subtract({ months: 16 }).add({ days: 16 }).toJSDate(),
							y: 3013,
						},
						{
							x: now.subtract({ months: 16 }).add({ days: 19 }).toJSDate(),
							y: 2760,
						},
						{
							x: now.subtract({ months: 16 }).add({ days: 22 }).toJSDate(),
							y: 3021,
						},
						{
							x: now.subtract({ months: 16 }).add({ days: 25 }).toJSDate(),
							y: 2688,
						},
						{
							x: now.subtract({ months: 16 }).add({ days: 28 }).toJSDate(),
							y: 2572,
						},
						{
							x: now.subtract({ months: 15 }).add({ days: 1 }).toJSDate(),
							y: 2789,
						},
						{
							x: now.subtract({ months: 15 }).add({ days: 4 }).toJSDate(),
							y: 3069,
						},
						{
							x: now.subtract({ months: 15 }).add({ days: 7 }).toJSDate(),
							y: 3142,
						},
						{
							x: now.subtract({ months: 15 }).add({ days: 10 }).toJSDate(),
							y: 3614,
						},
						{
							x: now.subtract({ months: 15 }).add({ days: 13 }).toJSDate(),
							y: 3202,
						},
						{
							x: now.subtract({ months: 15 }).add({ days: 16 }).toJSDate(),
							y: 2730,
						},
						{
							x: now.subtract({ months: 15 }).add({ days: 19 }).toJSDate(),
							y: 2951,
						},
						{
							x: now.subtract({ months: 15 }).add({ days: 22 }).toJSDate(),
							y: 3267,
						},
						{
							x: now.subtract({ months: 15 }).add({ days: 25 }).toJSDate(),
							y: 2882,
						},
						{
							x: now.subtract({ months: 15 }).add({ days: 28 }).toJSDate(),
							y: 2885,
						},
						{
							x: now.subtract({ months: 14 }).add({ days: 1 }).toJSDate(),
							y: 2915,
						},
						{
							x: now.subtract({ months: 14 }).add({ days: 4 }).toJSDate(),
							y: 2790,
						},
						{
							x: now.subtract({ months: 14 }).add({ days: 7 }).toJSDate(),
							y: 3071,
						},
						{
							x: now.subtract({ months: 14 }).add({ days: 10 }).toJSDate(),
							y: 2802,
						},
						{
							x: now.subtract({ months: 14 }).add({ days: 13 }).toJSDate(),
							y: 2382,
						},
						{
							x: now.subtract({ months: 14 }).add({ days: 16 }).toJSDate(),
							y: 1883,
						},
						{
							x: now.subtract({ months: 14 }).add({ days: 19 }).toJSDate(),
							y: 1448,
						},
						{
							x: now.subtract({ months: 14 }).add({ days: 22 }).toJSDate(),
							y: 1176,
						},
						{
							x: now.subtract({ months: 14 }).add({ days: 25 }).toJSDate(),
							y: 1275,
						},
						{
							x: now.subtract({ months: 14 }).add({ days: 28 }).toJSDate(),
							y: 1136,
						},
						{
							x: now.subtract({ months: 13 }).add({ days: 1 }).toJSDate(),
							y: 1160,
						},
						{
							x: now.subtract({ months: 13 }).add({ days: 4 }).toJSDate(),
							y: 1524,
						},
						{
							x: now.subtract({ months: 13 }).add({ days: 7 }).toJSDate(),
							y: 1305,
						},
						{
							x: now.subtract({ months: 13 }).add({ days: 10 }).toJSDate(),
							y: 1725,
						},
						{
							x: now.subtract({ months: 13 }).add({ days: 13 }).toJSDate(),
							y: 1850,
						},
						{
							x: now.subtract({ months: 13 }).add({ days: 16 }).toJSDate(),
							y: 2304,
						},
						{
							x: now.subtract({ months: 13 }).add({ days: 19 }).toJSDate(),
							y: 2187,
						},
						{
							x: now.subtract({ months: 13 }).add({ days: 22 }).toJSDate(),
							y: 2597,
						},
						{
							x: now.subtract({ months: 13 }).add({ days: 25 }).toJSDate(),
							y: 2246,
						},
						{
							x: now.subtract({ months: 13 }).add({ days: 28 }).toJSDate(),
							y: 1767,
						},
					],
				},
			],
		},
	},
	conversions: {
		amount: 4123,
		labels: [
			now.subtract({ days: 47 }).format('dd MMM') + ' - ' + now.subtract({ days: 40 }).format('dd MMM'),
			now.subtract({ days: 39 }).format('dd MMM') + ' - ' + now.subtract({ days: 32 }).format('dd MMM'),
			now.subtract({ days: 31 }).format('dd MMM') + ' - ' + now.subtract({ days: 24 }).format('dd MMM'),
			now.subtract({ days: 23 }).format('dd MMM') + ' - ' + now.subtract({ days: 16 }).format('dd MMM'),
			now.subtract({ days: 15 }).format('dd MMM') + ' - ' + now.subtract({ days: 8 }).format('dd MMM'),
			now.subtract({ days: 7 }).format('dd MMM') + ' - ' + now.format('dd MMM'),
		],
		series: [
			{
				name: 'Conversions',
				data: [4412, 4345, 4541, 4677, 4322, 4123],
			},
		],
	},
	impressions: {
		amount: 46085,
		labels: [
			now.subtract({ days: 31 }).format('dd MMM') + ' - ' + now.subtract({ days: 24 }).format('dd MMM'),
			now.subtract({ days: 23 }).format('dd MMM') + ' - ' + now.subtract({ days: 16 }).format('dd MMM'),
			now.subtract({ days: 15 }).format('dd MMM') + ' - ' + now.subtract({ days: 8 }).format('dd MMM'),
			now.subtract({ days: 7 }).format('dd MMM') + ' - ' + now.format('dd MMM'),
		],
		series: [
			{
				name: 'Impressions',
				data: [11577, 11441, 11544, 11523],
			},
		],
	},
	visits: {
		amount: 62083,
		labels: [
			now.subtract({ days: 31 }).format('dd MMM') + ' - ' + now.subtract({ days: 24 }).format('dd MMM'),
			now.subtract({ days: 23 }).format('dd MMM') + ' - ' + now.subtract({ days: 16 }).format('dd MMM'),
			now.subtract({ days: 15 }).format('dd MMM') + ' - ' + now.subtract({ days: 8 }).format('dd MMM'),
			now.subtract({ days: 7 }).format('dd MMM') + ' - ' + now.format('dd MMM'),
		],
		series: [
			{
				name: 'Visits',
				data: [15521, 15519, 15522, 15521],
			},
		],
	},
	visitorsVsPageViews: {
		overallScore: 472,
		averageRatio: 45,
		predictedRatio: 55,
		series: [
			{
				name: 'Page Views',
				data: [
					{
						x: now.subtract({ days: 65 }).toJSDate(),
						y: 4769,
					},
					{
						x: now.subtract({ days: 64 }).toJSDate(),
						y: 4901,
					},
					{
						x: now.subtract({ days: 63 }).toJSDate(),
						y: 4640,
					},
					{
						x: now.subtract({ days: 62 }).toJSDate(),
						y: 5128,
					},
					{
						x: now.subtract({ days: 61 }).toJSDate(),
						y: 5015,
					},
					{
						x: now.subtract({ days: 60 }).toJSDate(),
						y: 5360,
					},
					{
						x: now.subtract({ days: 59 }).toJSDate(),
						y: 5608,
					},
					{
						x: now.subtract({ days: 58 }).toJSDate(),
						y: 5272,
					},
					{
						x: now.subtract({ days: 57 }).toJSDate(),
						y: 5660,
					},
					{
						x: now.subtract({ days: 56 }).toJSDate(),
						y: 6026,
					},
					{
						x: now.subtract({ days: 55 }).toJSDate(),
						y: 5836,
					},
					{
						x: now.subtract({ days: 54 }).toJSDate(),
						y: 5659,
					},
					{
						x: now.subtract({ days: 53 }).toJSDate(),
						y: 5575,
					},
					{
						x: now.subtract({ days: 52 }).toJSDate(),
						y: 5474,
					},
					{
						x: now.subtract({ days: 51 }).toJSDate(),
						y: 5427,
					},
					{
						x: now.subtract({ days: 50 }).toJSDate(),
						y: 5865,
					},
					{
						x: now.subtract({ days: 49 }).toJSDate(),
						y: 5700,
					},
					{
						x: now.subtract({ days: 48 }).toJSDate(),
						y: 6052,
					},
					{
						x: now.subtract({ days: 47 }).toJSDate(),
						y: 5760,
					},
					{
						x: now.subtract({ days: 46 }).toJSDate(),
						y: 5648,
					},
					{
						x: now.subtract({ days: 45 }).toJSDate(),
						y: 5510,
					},
					{
						x: now.subtract({ days: 44 }).toJSDate(),
						y: 5435,
					},
					{
						x: now.subtract({ days: 43 }).toJSDate(),
						y: 5239,
					},
					{
						x: now.subtract({ days: 42 }).toJSDate(),
						y: 5452,
					},
					{
						x: now.subtract({ days: 41 }).toJSDate(),
						y: 5416,
					},
					{
						x: now.subtract({ days: 40 }).toJSDate(),
						y: 5195,
					},
					{
						x: now.subtract({ days: 39 }).toJSDate(),
						y: 5119,
					},
					{
						x: now.subtract({ days: 38 }).toJSDate(),
						y: 4635,
					},
					{
						x: now.subtract({ days: 37 }).toJSDate(),
						y: 4833,
					},
					{
						x: now.subtract({ days: 36 }).toJSDate(),
						y: 4584,
					},
					{
						x: now.subtract({ days: 35 }).toJSDate(),
						y: 4822,
					},
					{
						x: now.subtract({ days: 34 }).toJSDate(),
						y: 4330,
					},
					{
						x: now.subtract({ days: 33 }).toJSDate(),
						y: 4582,
					},
					{
						x: now.subtract({ days: 32 }).toJSDate(),
						y: 4348,
					},
					{
						x: now.subtract({ days: 31 }).toJSDate(),
						y: 4132,
					},
					{
						x: now.subtract({ days: 30 }).toJSDate(),
						y: 4099,
					},
					{
						x: now.subtract({ days: 29 }).toJSDate(),
						y: 3849,
					},
					{
						x: now.subtract({ days: 28 }).toJSDate(),
						y: 4010,
					},
					{
						x: now.subtract({ days: 27 }).toJSDate(),
						y: 4486,
					},
					{
						x: now.subtract({ days: 26 }).toJSDate(),
						y: 4403,
					},
					{
						x: now.subtract({ days: 25 }).toJSDate(),
						y: 4141,
					},
					{
						x: now.subtract({ days: 24 }).toJSDate(),
						y: 3780,
					},
					{
						x: now.subtract({ days: 23 }).toJSDate(),
						y: 3929,
					},
					{
						x: now.subtract({ days: 22 }).toJSDate(),
						y: 3524,
					},
					{
						x: now.subtract({ days: 21 }).toJSDate(),
						y: 3212,
					},
					{
						x: now.subtract({ days: 20 }).toJSDate(),
						y: 3568,
					},
					{
						x: now.subtract({ days: 19 }).toJSDate(),
						y: 3800,
					},
					{
						x: now.subtract({ days: 18 }).toJSDate(),
						y: 3796,
					},
					{
						x: now.subtract({ days: 17 }).toJSDate(),
						y: 3870,
					},
					{
						x: now.subtract({ days: 16 }).toJSDate(),
						y: 3745,
					},
					{
						x: now.subtract({ days: 15 }).toJSDate(),
						y: 3751,
					},
					{
						x: now.subtract({ days: 14 }).toJSDate(),
						y: 3310,
					},
					{
						x: now.subtract({ days: 13 }).toJSDate(),
						y: 3509,
					},
					{
						x: now.subtract({ days: 12 }).toJSDate(),
						y: 3311,
					},
					{
						x: now.subtract({ days: 11 }).toJSDate(),
						y: 3187,
					},
					{
						x: now.subtract({ days: 10 }).toJSDate(),
						y: 2918,
					},
					{
						x: now.subtract({ days: 9 }).toJSDate(),
						y: 3191,
					},
					{
						x: now.subtract({ days: 8 }).toJSDate(),
						y: 3437,
					},
					{
						x: now.subtract({ days: 7 }).toJSDate(),
						y: 3291,
					},
					{
						x: now.subtract({ days: 6 }).toJSDate(),
						y: 3317,
					},
					{
						x: now.subtract({ days: 5 }).toJSDate(),
						y: 3716,
					},
					{
						x: now.subtract({ days: 4 }).toJSDate(),
						y: 3260,
					},
					{
						x: now.subtract({ days: 3 }).toJSDate(),
						y: 3694,
					},
					{
						x: now.subtract({ days: 2 }).toJSDate(),
						y: 3598,
					},
					{
						x: now.subtract({ days: 1 }).toJSDate(),
						y: 3812,
					},
				],
			},
			{
				name: 'Visitors',
				data: [
					{
						x: now.subtract({ days: 65 }).toJSDate(),
						y: 1654,
					},
					{
						x: now.subtract({ days: 64 }).toJSDate(),
						y: 1900,
					},
					{
						x: now.subtract({ days: 63 }).toJSDate(),
						y: 1647,
					},
					{
						x: now.subtract({ days: 62 }).toJSDate(),
						y: 1315,
					},
					{
						x: now.subtract({ days: 61 }).toJSDate(),
						y: 1807,
					},
					{
						x: now.subtract({ days: 60 }).toJSDate(),
						y: 1793,
					},
					{
						x: now.subtract({ days: 59 }).toJSDate(),
						y: 1892,
					},
					{
						x: now.subtract({ days: 58 }).toJSDate(),
						y: 1846,
					},
					{
						x: now.subtract({ days: 57 }).toJSDate(),
						y: 1966,
					},
					{
						x: now.subtract({ days: 56 }).toJSDate(),
						y: 1804,
					},
					{
						x: now.subtract({ days: 55 }).toJSDate(),
						y: 1778,
					},
					{
						x: now.subtract({ days: 54 }).toJSDate(),
						y: 2015,
					},
					{
						x: now.subtract({ days: 53 }).toJSDate(),
						y: 1892,
					},
					{
						x: now.subtract({ days: 52 }).toJSDate(),
						y: 1708,
					},
					{
						x: now.subtract({ days: 51 }).toJSDate(),
						y: 1711,
					},
					{
						x: now.subtract({ days: 50 }).toJSDate(),
						y: 1570,
					},
					{
						x: now.subtract({ days: 49 }).toJSDate(),
						y: 1507,
					},
					{
						x: now.subtract({ days: 48 }).toJSDate(),
						y: 1451,
					},
					{
						x: now.subtract({ days: 47 }).toJSDate(),
						y: 1522,
					},
					{
						x: now.subtract({ days: 46 }).toJSDate(),
						y: 1801,
					},
					{
						x: now.subtract({ days: 45 }).toJSDate(),
						y: 1977,
					},
					{
						x: now.subtract({ days: 44 }).toJSDate(),
						y: 2367,
					},
					{
						x: now.subtract({ days: 43 }).toJSDate(),
						y: 2798,
					},
					{
						x: now.subtract({ days: 42 }).toJSDate(),
						y: 3080,
					},
					{
						x: now.subtract({ days: 41 }).toJSDate(),
						y: 2856,
					},
					{
						x: now.subtract({ days: 40 }).toJSDate(),
						y: 2745,
					},
					{
						x: now.subtract({ days: 39 }).toJSDate(),
						y: 2750,
					},
					{
						x: now.subtract({ days: 38 }).toJSDate(),
						y: 2728,
					},
					{
						x: now.subtract({ days: 37 }).toJSDate(),
						y: 2436,
					},
					{
						x: now.subtract({ days: 36 }).toJSDate(),
						y: 2289,
					},
					{
						x: now.subtract({ days: 35 }).toJSDate(),
						y: 2657,
					},
					{
						x: now.subtract({ days: 34 }).toJSDate(),
						y: 2804,
					},
					{
						x: now.subtract({ days: 33 }).toJSDate(),
						y: 2777,
					},
					{
						x: now.subtract({ days: 32 }).toJSDate(),
						y: 3024,
					},
					{
						x: now.subtract({ days: 31 }).toJSDate(),
						y: 2657,
					},
					{
						x: now.subtract({ days: 30 }).toJSDate(),
						y: 2218,
					},
					{
						x: now.subtract({ days: 29 }).toJSDate(),
						y: 1964,
					},
					{
						x: now.subtract({ days: 28 }).toJSDate(),
						y: 1674,
					},
					{
						x: now.subtract({ days: 27 }).toJSDate(),
						y: 1721,
					},
					{
						x: now.subtract({ days: 26 }).toJSDate(),
						y: 2005,
					},
					{
						x: now.subtract({ days: 25 }).toJSDate(),
						y: 1613,
					},
					{
						x: now.subtract({ days: 24 }).toJSDate(),
						y: 1295,
					},
					{
						x: now.subtract({ days: 23 }).toJSDate(),
						y: 1071,
					},
					{
						x: now.subtract({ days: 22 }).toJSDate(),
						y: 799,
					},
					{
						x: now.subtract({ days: 21 }).toJSDate(),
						y: 1133,
					},
					{
						x: now.subtract({ days: 20 }).toJSDate(),
						y: 1536,
					},
					{
						x: now.subtract({ days: 19 }).toJSDate(),
						y: 2016,
					},
					{
						x: now.subtract({ days: 18 }).toJSDate(),
						y: 2256,
					},
					{
						x: now.subtract({ days: 17 }).toJSDate(),
						y: 1934,
					},
					{
						x: now.subtract({ days: 16 }).toJSDate(),
						y: 1832,
					},
					{
						x: now.subtract({ days: 15 }).toJSDate(),
						y: 2075,
					},
					{
						x: now.subtract({ days: 14 }).toJSDate(),
						y: 1709,
					},
					{
						x: now.subtract({ days: 13 }).toJSDate(),
						y: 1932,
					},
					{
						x: now.subtract({ days: 12 }).toJSDate(),
						y: 1831,
					},
					{
						x: now.subtract({ days: 11 }).toJSDate(),
						y: 1434,
					},
					{
						x: now.subtract({ days: 10 }).toJSDate(),
						y: 993,
					},
					{
						x: now.subtract({ days: 9 }).toJSDate(),
						y: 1064,
					},
					{
						x: now.subtract({ days: 8 }).toJSDate(),
						y: 618,
					},
					{
						x: now.subtract({ days: 7 }).toJSDate(),
						y: 1032,
					},
					{
						x: now.subtract({ days: 6 }).toJSDate(),
						y: 1280,
					},
					{
						x: now.subtract({ days: 5 }).toJSDate(),
						y: 1344,
					},
					{
						x: now.subtract({ days: 4 }).toJSDate(),
						y: 1835,
					},
					{
						x: now.subtract({ days: 3 }).toJSDate(),
						y: 2287,
					},
					{
						x: now.subtract({ days: 2 }).toJSDate(),
						y: 2226,
					},
					{
						x: now.subtract({ days: 1 }).toJSDate(),
						y: 2692,
					},
				],
			},
		],
	},
	newVsReturning: {
		uniqueVisitors: 46085,
		series: [80, 20],
		labels: [
			'New',
			'Returning',
		],
	},
	gender: {
		uniqueVisitors: 46085,
		series: [55, 45],
		labels: [
			'Male',
			'Female',
		],
	},
	age: {
		uniqueVisitors: 46085,
		series: [35, 65],
		labels: [
			'Under 30',
			'Over 30',
		],
	},
	language: {
		uniqueVisitors: 46085,
		series: [25, 75],
		labels: [
			'English',
			'Other',
		],
	},
};
