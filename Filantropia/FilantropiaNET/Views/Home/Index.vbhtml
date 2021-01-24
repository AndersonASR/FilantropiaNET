@Code
    ViewData("Title") = "Home Page"
End Code

<div class="jumbotron">
    <h1>Sistema Filantropia</h1>
    <p class="lead">Filantropia é um sistema privado para auxiliar no processo de gestão de doações.</p>
    <p class="lead">Por se tratar de uma aplicação particular, faz-se necessário a autenticação no sistema para sua utilização..</p>
</div>
@Using Html.BeginForm("Login", "Home")
@<div class="row">
     <div class="col-md-4">
         <h2>Login</h2>
         <p>
             Por favor, preencha suas credenciais para acessar a aplicação
         </p>
         <div class="form-group">
             <p>
                 CPF : &nbsp;&nbsp;&nbsp;&nbsp;
                 <input type="text" id="txtCPF" name="txtCPF" />
             </p>
         </div>
         <div class="form-group">
             <p>
                 Senha : &nbsp; <input type="password" ID="txtSenha" name="txtSenha" />
             </p>
         </div>
         <p>
            <p> <button type="submit" Class="btn btn-default">Login</button></p>
         </p>
     </div>
 </div>
End Using