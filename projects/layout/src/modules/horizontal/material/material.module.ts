import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MaterialLayoutComponent } from './material.component';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { VerticalNavigationModule } from '../../../components/vertical';
import { HorizontalNavigationModule } from '../../../components/horizontal';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
	declarations: [
		MaterialLayoutComponent
	],
	imports: [
		RouterModule,
		MatIconModule,
		LoadingBarComponent,
		VerticalNavigationModule,
		HorizontalNavigationModule
	],
	exports: [
		MaterialLayoutComponent,
	]
})
export class MaterialLayoutModule {
}
