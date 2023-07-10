import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DenseLayoutComponent } from './dense.component';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { VerticalNavigationModule } from '../../../components/vertical';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
	declarations: [
		DenseLayoutComponent
	],
	imports: [
		RouterModule,
		MatIconModule,
		LoadingBarComponent,
		VerticalNavigationModule
	],
	exports: [
		DenseLayoutComponent,
	]
})
export class DenseLayoutModule {
}
