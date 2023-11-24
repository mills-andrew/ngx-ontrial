import { provideHttpClient } from '@angular/common/http';
import { APP_INITIALIZER, ApplicationConfig } from '@angular/core';
import { DateAdapter as AngularDateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { provideAnimations } from '@angular/platform-browser/animations';
import { PreloadAllModules, provideRouter, withInMemoryScrolling, withPreloading } from '@angular/router';
import { DateAdapter, ConfigService, provideDefaultIcons, provideOntrial, provideTransloco, DateTime } from '@ngx-ontrial/core';
import { appRoutes } from './app.router';
import { provideAuth, provideMockApi } from '@ngx-ontrial/auth';
import { mockApiServices } from '../mock-api/';

export const ProvidersConfig: ApplicationConfig = {
	providers: [
		{
			provide: APP_INITIALIZER,
			useFactory: (appConfigService: ConfigService) => () => appConfigService.load('/assets/app.config.json'),
			deps: [ConfigService],
			multi: true
		},

		provideAnimations(),
		provideHttpClient(),
		provideRouter(appRoutes,
			withPreloading(PreloadAllModules),
			withInMemoryScrolling({ scrollPositionRestoration: 'enabled' }),
		),

		// Material Date Adapter
		{ provide: MAT_DATE_LOCALE, useValue: 'en-US' },
		{ provide: AngularDateAdapter, useClass: DateAdapter, deps: [DateTime, MAT_DATE_LOCALE] },
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
			scheme: 'auto',
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
