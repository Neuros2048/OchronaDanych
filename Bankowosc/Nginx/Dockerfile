FROM nginx:alpine
WORKDIR /app
EXPOSE 443
COPY nginx.conf /etc/nginx/nginx.conf
COPY Bank.crt /etc/nginx/sv.crt
COPY bank.key /etc/nginx/sv_private.key
