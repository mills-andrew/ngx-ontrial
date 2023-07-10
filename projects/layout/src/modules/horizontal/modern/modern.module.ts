import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ModernLayoutComponent } from './modern.component';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { VerticalNavigationModule } from '../../../components/vertical';
import { HorizontalNavigationModule } from '../../../components/horizontal';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
	declarations: [
		ModernLayoutComponent
	],
	imports: [
		RouterModule,
		MatIconModule,
		LoadingBarComponent,
		VerticalNavigationModule,
		HorizontalNavigationModule
	],
	exports: [
		ModernLayoutComponent,
	]
})
export class ModernLayoutModule {
}
