import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TrabajadorService {

  private apiUrl = 'http://localhost:44846/Trabajador';

  constructor(private http: HttpClient) { }

  getTipoTrabajadores(idTipo:number) {
    return this.http.get<any>(this.apiUrl+"/tipo/"+idTipo);
  }

  getBuscarTrabajador(dni:string){
    return this.http.get<any>(this.apiUrl+"/buscar/"+dni);
  }
}
