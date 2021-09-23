import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";


export class ImageService {


  constructor(private http: HttpClient) { }

  getImage(imageUrl: string): Observable<Blob> {

    return this.http.get(imageUrl, { responseType: 'blob' });
  }

}
