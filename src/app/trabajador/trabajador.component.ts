import { Component, OnInit } from '@angular/core';
import { TrabajadorService } from '../services/trabajador.service';

@Component({
  selector: 'app-trabajador',
  templateUrl: './trabajador.component.html',
  styleUrls: ['./trabajador.component.css']
})
export class TrabajadorComponent implements OnInit {

  selectedOption: string = "0";
  inputDNI="";
  trabajadores: any[]=[];
  constructor(private trabajadorService: TrabajadorService) { }

  ngOnInit(): void {
    this.listarTipoTrabajador();
  }


  listarTipoTrabajador(){
    this.trabajadorService.getTipoTrabajadores(parseInt(this.selectedOption)).subscribe(response=>{
      if(response.estado){
        this.trabajadores=response.data
      }else{
        this.trabajadores=[];
      }
    });
  }

  tipoTrabajador(idTipoTrabajador:number){
    return idTipoTrabajador==0? "Obrero":idTipoTrabajador==1? "Supervisor":"Gerente";
  }

  colorTipoTrabajador(idTipoTrabajador:number){
    return idTipoTrabajador==0? "#6FE592":idTipoTrabajador==1? "#AD7AE8":"#D1DC87";
  }

  buscarDNIEmpleado(){
    this.trabajadorService.getBuscarTrabajador(this.inputDNI).subscribe(response=>{
      if(response.estado){
        this.trabajadores=response.data
      }else{
        this.trabajadores=[];
      }
    });
  }
}
