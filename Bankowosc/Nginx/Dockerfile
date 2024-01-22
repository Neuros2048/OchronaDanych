FROM nginx:alpine
WORKDIR /app
EXPOSE 443
COPY nginx.conf /etc/nginx/nginx.conf
COPY sv.crt /etc/nginx/sv.crt
COPY sv_private.key /etc/nginx/sv_private.key
