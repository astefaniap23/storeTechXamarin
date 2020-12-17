-------Insertar registros

--categoria

INSERT INTO categoria(nombre,descripcion,estado)
VALUES ('Laptops','Laptos importados',1);

INSERT INTO categoria(nombre,descripcion,estado)
VALUES ('Impresoras','Impresoras Laser/Tinta',1);

---producto

INSERT INTO producto(idcategoria,codigo_fabrica,nombre,precio_venta,stock,descripcion)
VALUES (1,'12345','Laptop Lenovo',1800,20,'i5 4GB RAM');

INSERT INTO producto(idcategoria,codigo_fabrica,nombre,precio_venta,stock,descripcion)
VALUES (1,'23456','Laptop Acer',2800,20,'i5 8GB RAM');


INSERT INTO producto(idcategoria,codigo_fabrica,nombre,precio_venta,stock,descripcion)
VALUES (2,'234567','Impresora 3D',1200,80,'3D CON 2 COLORES');


INSERT INTO producto(idcategoria,codigo_fabrica,nombre,precio_venta,stock,descripcion)
VALUES (2,'234567','Impresora Samsung',700,60,'Tinta Wifi');

----- Query

-- Categoria Producto

SELECT P.nombre, P.precio_venta,P.stock, P.descripcion,
C.nombre from producto P JOIN categoria C on P.idcategoria= C.idcategoria
WHERE P.idproducto=1 and C.idcategoria=1;