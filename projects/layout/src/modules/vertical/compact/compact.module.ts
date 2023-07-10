import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CompactLayoutComponent } from './compact.component';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { VerticalNavigationModule } from '../../../components/vertical';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
	declarations: [
		CompactLayoutComponent
	],
	imports: [
		RouterModule,
		MatIconModule,
		LoadingBarComponent,
		VerticalNavigationModule
	],
	exports: [
		CompactLayoutComponent,
	]
})
export class CompactLayoutModule {
}
