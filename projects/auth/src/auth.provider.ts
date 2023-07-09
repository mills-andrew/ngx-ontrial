import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { APP_INITIALIZER, ENVIRONMENT_INITIALIZER, EnvironmentProviders, inject, Provider } from '@angular/core';
import { authInterceptor } from './auth.interceptor';
import { AuthService } from './auth.service';
import { ONTRIAL_MOCK_API_DEFAULT_DELAY, mockApiInterceptor } from './mock-api';

export type ProviderConfig = {
	delay?: number;
	services?: any[];
}

export const provideMockApi = (config: ProviderConfig): Array<Provider | EnvironmentProviders> => {
	const providers: Array<Provider | EnvironmentProviders> = [
		{
			provide: ONTRIAL_MOCK_API_DEFAULT_DELAY,
			useValue: config?.delay ?? 0,
		}
	];

	// Mock Api services
	if (config?.services) {
		providers.push(
			provideHttpClient(withInterceptors([mockApiInterceptor])),
			{
				provide: APP_INITIALIZER,
				deps: [...config.services],
				useFactory: () => (): any => null,
				multi: true,
			},
		);
	}

	return providers;
};

export const provideAuth = (): Array<Provider | EnvironmentProviders> => {
	return [
		provideHttpClient(withInterceptors([authInterceptor])),
		{
			provide: ENVIRONMENT_INITIALIZER,
			useValue: () => inject(AuthService),
			multi: true,
		},
	];
};
