import { NgModule } from '@angular/core';
import { VerticalNavigationComponent } from './vertical.component';
import { VerticalNavigationAsideItemModule } from './components/aside/aside.module';
import { VerticalNavigationBasicItemModule } from './components/basic/basic.module';
import { VerticalNavigationCollapsableItemModule } from './components/collapsable/collapsable.module';
import { VerticalNavigationDividerItemModule } from './components/divider/divider.module';
import { VerticalNavigationSpacerItemModule } from './components/spacer/spacer.module';

@NgModule({
	declarations: [
		VerticalNavigationComponent
	],
	imports: [
		VerticalNavigationAsideItemModule,
		VerticalNavigationBasicItemModule,
		VerticalNavigationCollapsableItemModule,
		VerticalNavigationDividerItemModule,
		VerticalNavigationAsideItemModule,
		VerticalNavigationSpacerItemModule
	],
	exports: [
		VerticalNavigationComponent,
	]
})
export class VerticalNavigationModule {
}
