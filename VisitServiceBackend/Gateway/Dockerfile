# Utilizar la imagen oficial de NGINX
FROM nginx:latest
RUN rm /etc/nginx/conf.d/default.conf
# Copiar el archivo nginx.conf personalizado al contenedor
COPY Gateway/nginx.conf /etc/nginx/nginx.conf

# Iniciar NGINX
CMD ["nginx", "-g", "daemon off;"]
