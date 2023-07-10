import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EnterpriseLayoutComponent } from './enterprise.component';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { VerticalNavigationModule } from '../../../components/vertical';
import { HorizontalNavigationModule } from '../../../components/horizontal';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
	declarations: [
		EnterpriseLayoutComponent
	],
	imports: [
		RouterModule,
		MatIconModule,
		LoadingBarComponent,
		VerticalNavigationModule,
		HorizontalNavigationModule
	],
	exports: [
		EnterpriseLayoutComponent,
	]
})
export class EnterpriseLayoutModule {
}
