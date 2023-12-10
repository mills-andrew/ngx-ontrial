import { Injectable } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

@Injectable({ providedIn: 'root' })
export class IconsService {
	constructor(
		private domSanitizer: DomSanitizer,
		private matIconRegistry: MatIconRegistry
	) { }

	registerIconSets(iconSets: { namespace: string, url: string }[]) {
		iconSets.forEach((iconSet) => {

			if (iconSet.namespace === '') {
				this.matIconRegistry.addSvgIconSet(
					this.domSanitizer.bypassSecurityTrustResourceUrl(iconSet.url)
				);
			} else {
				this.matIconRegistry.addSvgIconSetInNamespace(
					iconSet.namespace,
					this.domSanitizer.bypassSecurityTrustResourceUrl(iconSet.url)
				);
			}
		});
	}
}
