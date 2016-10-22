var express = require('express');
var app = express();

var random = function (low, high) {
    return parseInt(Math.random() * (high - low) + low, 10);
};

var sitios = [
	{
	    nombre: "Mi Sitio 1",
	    titulo: "Sitio Exclusivo 1",
	    descripcion: "Este es uno de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	},
	{
	    nombre: "Mi Sitio 2",
	    titulo: "Sitio Exclusivo 2",
	    descripcion: "Este es el segundo de los mejores sitios de Guatemala y del mundo. Donde puedes encontrar fauna, flora y cálidos paisajes..",
	    ranking: random(1,5),
	    imagen: "img/chiquimula3.jpg"
	}
];

var addId = function(){
	for(var i=0; i<sitios.length; i++) {
		sitios[i].id = 100 + (i+1);
	}
};

var addDescGral = function(){
	for(var i=0; i<sitios.length; i++) {
		sitios[i].info = "Información turística aquí: Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias voluptate, soluta deserunt illum eaque quaerat? Aliquid assumenda sit, placeat, ea dicta quae ipsam quisquam quia, nisi et tenetur numquam modi! Lorem ipsum dolor sit amet, consectetur adipisicing elit.";
		sitios[i].datos = "Dirección y ubcación aquí: Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias voluptate, soluta deserunt illum eaque quaerat? Aliquid assumenda sit, placeat, ea dicta quae ipsam quisquam quia, nisi et tenetur numquam modi! Lorem ipsum dolor sit amet, consectetur adipisicing elit.";
		sitios[i].masdatos = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias voluptate, soluta deserunt illum eaque quaerat? Aliquid assumenda sit, placeat, ea dicta quae ipsam quisquam quia, nisi et tenetur numquam modi! Lorem ipsum dolor sit amet, consectetur adipisicing elit.";
		sitios[i].horario = "Abierto todo el día";
		sitios[i].precio = "Q. 0.00 GRATIS";
	}
};

var getById = function(mId){
	for(var i=0; i<sitios.length; i++) {
		if(sitios[i].id == mId) 
			return sitios[i];
	}
	return null;
};


app.get('/', function(req, res) {
 res.send('Bienvenido al Web Api de Chiquimula Tour');
});

app.get('/sitios', function(req, res) {
 res.setHeader('Content-Type', 'application/json');
 addId();
 res.send(JSON.stringify(sitios));
});

app.get('/sitios/:id', function(req, res) {
 res.setHeader('Content-Type', 'application/json');
 addId();
 addDescGral();
 var id = req.params.id;
 var obj = getById(id);
 res.send(JSON.stringify(obj));
});


app.listen(3000, function () {
  console.log('Example app listening on port 3000!');
});

