import { bootstrapApplication } from '@angular/platform-browser';

import { ProvidersConfig } from './app/app.config';
import { AppComponent } from './app/app.component';

bootstrapApplication(AppComponent, ProvidersConfig)
	.catch(err => console.error(err));
