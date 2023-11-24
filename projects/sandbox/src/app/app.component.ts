import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { appRoutes, maintenaceRoutes } from './app.router';
import { ConfigService } from '@ngx-ontrial/core';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss'],
	standalone: true,
	imports: [RouterOutlet]
})
export class AppComponent {
	title = 'sandbox';

	constructor(
		private router: Router,
		private configService: ConfigService,
	) {

	}

	ngOnInit() {
		if (this.configService.config) {
			const inMaintenanceMode = this.configService.config.inMaintenanceMode;

			if (inMaintenanceMode) {
				this.router.resetConfig(maintenaceRoutes);
			}
		}
	}

}
