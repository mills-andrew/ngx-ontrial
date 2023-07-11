import { provideHttpClient } from '@angular/common/http';
import { ApplicationConfig } from '@angular/core';
// import { LuxonDateAdapter } from '@angular/material-luxon-adapter';
import { DateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';
import { provideAnimations } from '@angular/platform-browser/animations';
import { PreloadAllModules, provideRouter, withInMemoryScrolling, withPreloading } from '@angular/router';
import { provideDefaultIcons, provideOntrial, provideTransloco } from '@ngx-ontrial/core';
import { appRoutes } from './app.router';
import { provideAuth, provideMockApi } from '@ngx-ontrial/auth';
import { mockApiServices } from '../mock-api/';

export const AppConfig: ApplicationConfig = {
	providers: [
		provideAnimations(),
		provideHttpClient(),
		provideRouter(appRoutes,
			withPreloading(PreloadAllModules),
			withInMemoryScrolling({ scrollPositionRestoration: 'enabled' }),
		),

		// Material Date Adapter
		// {
		// 	provide: DateAdapter,
		// 	useClass: LuxonDateAdapter,
		// },
		{
			provide: MAT_DATE_FORMATS,
			useValue: {
				parse: {
					dateInput: 'D',
				},
				display: {
					dateInput: 'DDD',
					monthYearLabel: 'LLL yyyy',
					dateA11yLabel: 'DD',
					monthYearA11yLabel: 'LLLL yyyy',
				},
			},
		},

		// Transloco Config
		provideTransloco(),

		// Ontrial
		provideDefaultIcons(),
		provideAuth(),
		provideMockApi({
			delay: 0,
			services: mockApiServices,
		}),
		provideOntrial({
			layout: 'enterprise',
			scheme: 'light',
			screens: {
				sm: '600px',
				md: '960px',
				lg: '1280px',
				xl: '1440px',
			},
			theme: 'theme-default',
			themes: [
				{
					id: 'theme-default',
					name: 'Default',
				}
			]
		})
	]
};
